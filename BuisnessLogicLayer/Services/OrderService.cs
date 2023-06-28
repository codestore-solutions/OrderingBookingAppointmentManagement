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
            var connectionString = "";
            var client = new ServiceBusClient(connectionString);
            var sendor = client.CreateSender("add-new-order");


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
                var body = JsonSerializer.Serialize(newOrder);
                //var message = 
                await unitOfWork.OrderRepository.AddAsync(newOrder);
                await unitOfWork.SaveAsync();
            }

            return new ResponseDto
            {
                StatusCode = 200,
                Success = true,
                Data = response,
                Message = StringConstant.SuccessMessage
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
 
    }
}
