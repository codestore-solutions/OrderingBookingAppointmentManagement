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
                //double itemTotal = 0;
                var newOrder = new Order();
                mapper.Map(createOrderDto, newOrder);

                // Hardcoded delivery date
                DateTime deliveryDate = DateTime.Now.AddDays(2);
                newOrder.VendorId = ordersforVendors.VendorId;
                newOrder.DeliveryCharges = ordersforVendors.DeliveryCharges;
                newOrder.DeliveryDate = deliveryDate;

                foreach (var orderItem in ordersforVendors.OrderItems)
                {
                    var newOrderItem = new OrderItems();
                    mapper.Map(orderItem, newOrderItem);
                    newOrderItem.OrderId = newOrder.OrderId;
                   // itemTotal += (orderItem.Price * orderItem.Quantity);
                    productCount++;
                    newOrder.OrderItems.Add(newOrderItem);
                }
                // Number of Products in one order for same vendor.
                newOrder.ProductCount = productCount;
                // newOrder.ItemTotal    = itemTotal;   
                newOrder.CreatedDate = newOrder.UpdatedOn = DateTime.Now;
                // Invoice Amount Total
                // newOrder.TotalInvoiceAmount = itemTotal + createOrderDto.TipAmount + createOrderDto.TaxesAmount + ordersforVendors.DeliveryCharges;
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

                // Adding order to queue for processing.
                var body = JsonSerializer.Serialize(queueObj);
                var message = new ServiceBusMessage(body);
                await sender.SendMessageAsync(message);
            }
            return listOfOrders;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync(long userId , int pageNumber , int limit)
        {
            var orders = await unitOfWork.OrderRepository.GetByCondition(u => u.UserId == userId)
            .Include(c => c.OrderItems).OrderByDescending(c=>c.UpdatedOn).Skip((pageNumber-1)*limit).Take(limit).ToListAsync();
            return orders;
        }

        // Order list required in order-processing Module.
        public async Task<IEnumerable<Order>> GetOrdersListAsync(List<long> orderIds)
        {
            var listOfOrders = await unitOfWork.OrderRepository.GetAsQueryable()
            .Where(entity => orderIds.Contains(entity.OrderId)).ToListAsync();

            return listOfOrders;
        }
    }
}
