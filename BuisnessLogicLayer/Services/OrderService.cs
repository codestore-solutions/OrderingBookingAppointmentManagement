using AutoMapper;
using Azure.Messaging.ServiceBus;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using Entitites.Models;
using EntityLayer.Common;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using OrderingBooking.BL.IServices;
using System.Text.Json;

namespace OrderingBooking.BL.Services
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            // Connection string setup for azure bus service (queue)
            var connectionString = StringConstant.QueueConnectionString;
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(StringConstant.QueueName);

            var response = new List<Object>();

            foreach(var ordersforVendors in createOrderDto.OrdersForVendors)
            {
                long productCount = 0;
                var newOrder = new Order();
                newOrder.UserId                 = createOrderDto.UserId;
                newOrder.ShippingAddressId      = createOrderDto.ShipingAddressId;
                newOrder.CreatedDate            = createOrderDto.CreatedDate;
                newOrder.paymentStatus          = (Order.PaymentStatus)createOrderDto.paymentStatus;
                newOrder.paymentMode            = (Order.PaymentMode)createOrderDto.paymentMode;
                newOrder.PaymentId              = createOrderDto.PaymentId;
                newOrder.VendorId               = ordersforVendors.VendorId;
                newOrder.DeliveryCharges        = ordersforVendors.DeliveryCharges;
                newOrder.DeliveryDate           = ordersforVendors.DeliveryDate;
                TimeSpan deliveryTime           = TimeSpan.Parse(ordersforVendors.DeliveryTime);
                newOrder.DeliveryTime           = deliveryTime;
        
                foreach (var orderItem in ordersforVendors.OrderItems)
                {
                    var newOrderItem = new OrderItems();
                    newOrderItem.ProductId       = orderItem.ProductId;
                    newOrderItem.VarientId       = orderItem.VarientId;
                    newOrderItem.orderStatus     = (OrderItems.OrderStatus)orderItem.orderStatus;
                    newOrderItem.Quantity        = orderItem.Quantity;
                    newOrderItem.Price           = orderItem.Price;
                    newOrderItem.Discount        = orderItem.Discount;
                    newOrderItem.OrderId         = newOrder.OrderId;                   
                    productCount++;
                    newOrder.OrderItems.Add(newOrderItem);     
                }
                newOrder.ProductCount = productCount;
                response.Add(newOrder);

                await unitOfWork.OrderRepository.AddAsync(newOrder);
                await unitOfWork.SaveAsync();

                var queueObj = new SendOrderToQueueDto();
                
                queueObj.orderId             = newOrder.OrderId;
                queueObj.customerId          = createOrderDto.UserId;
                queueObj.vendorId            = ordersforVendors.VendorId;
                queueObj.shippingAddressId   = newOrder.ShippingAddressId;
                
                var body = JsonSerializer.Serialize(queueObj);
                var message = new ServiceBusMessage(body);
                await sender.SendMessageAsync(message);
            }

            return new ResponseDto
            {
                StatusCode  = 200,
                Success     = true,
                Data        = response,
                Message     = StringConstant.SuccessMessage
            };
        }
        public async Task<ResponseDto> GetAllOrdersAsync(long userId)
        {
            var orders = await unitOfWork.OrderRepository.GetAll().Include(c => c.OrderItems).Where(u => u.UserId == userId).ToListAsync();

            return new ResponseDto
            {
                StatusCode  = 200,
                Success     = true,
                Data        = orders,
                Message     = StringConstant.SuccessMessage
            };
        }
        public async Task<ResponseDto> GetOrdersList(List<long> orderIds)
        {
            var listOfOrders = new List<Object>();

            foreach (var orderId in orderIds)
            {
                var order = await unitOfWork.OrderRepository.GetByIdAsync(orderId);                
                if (order == null)
                {
                    return new ResponseDto
                    {
                        StatusCode = 400,
                        Success = false,
                        Data = StringConstant.InvalidInputError,
                        Message = StringConstant.ErrorMessage
                    };
                }
                var orderItems = order.OrderItems;
                listOfOrders.Add(order);
            }

            return new ResponseDto
            {
                Success = true,
                StatusCode = 200,
                Data = listOfOrders,
                Message = StringConstant.SuccessMessage
            };

        }

    }
}
