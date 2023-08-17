using AutoMapper;
using Azure.Messaging.ServiceBus;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using Entitites.Models;
using EntityLayer.Common;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using OrderingBooking.BL.IServices;
using System.Text.Json;

namespace OrderingBooking.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Order>> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            // Connection string setup for azure bus service (queue)
            var connectionString = StringConstant.QueueConnectionString;
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(StringConstant.QueueName);

            var listOfOrders = new List<Order>();

            foreach (var ordersforVendors in createOrderDto.OrdersForVendors)
            {
                long productCount = 0;
                var newOrder = new Order();
                mapper.Map(createOrderDto, newOrder);

                DateTime tomorrowDate = DateTime.Now.AddDays(1);
                newOrder.VendorId = ordersforVendors.VendorId;
                newOrder.DeliveryCharges = ordersforVendors.DeliveryCharges;
                newOrder.DeliveryDate = tomorrowDate;

                foreach (var orderItem in ordersforVendors.OrderItems)
                {
                    var newOrderItem = new OrderItems();
                    mapper.Map(orderItem, newOrderItem);
                    newOrderItem.OrderId = newOrder.OrderId;
                    productCount++;
                    newOrder.OrderItems.Add(newOrderItem);
                }
                newOrder.ProductCount = productCount;
                listOfOrders.Add(newOrder);

                await unitOfWork.OrderRepository.AddAsync(newOrder);
                await unitOfWork.SaveAsync();

                // Creating order and then pushing it into the queue
                var queueObj = new SendOrderToQueueDto
                {
                    orderId = newOrder.OrderId,
                    customerId = createOrderDto.UserId,
                    vendorId = ordersforVendors.VendorId,
                    shippingAddressId = newOrder.ShippingAddressId
                };

                var body = JsonSerializer.Serialize(queueObj);
                var message = new ServiceBusMessage(body);
                await sender.SendMessageAsync(message);
            }
            return listOfOrders;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync(long userId)
        {
            var orders = await unitOfWork.OrderRepository.GetByCondition(u => u.UserId == userId)
            .Include(c => c.OrderItems).ToListAsync();
            return orders;
        }
        public async Task<IEnumerable<Order>> GetOrdersListAsync(List<long> orderIds)
        {
            var listOfOrders = await unitOfWork.OrderRepository.GetAsQueryable()
                .Where(entity => orderIds.Contains(entity.OrderId)).ToListAsync();

            return listOfOrders;
        }
    }
}
