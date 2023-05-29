using BuisnessLogicLayer.IServices;
using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using EntityLayer;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLogicLayer.Services
{
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateNewOrderAsync(CreateNewOrder order)
        {
            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                OrderAmount = order.OrderAmount,
                OrderQty = order.OrderQty         
            };
           await unitOfWork.OrderRepository.AddAsync(newOrder);
           await unitOfWork.SaveAsync();
           return newOrder;    
        }
        public async Task<Order> DeleteOrderAsync(Guid id)
        {
            var deletedOrder= await unitOfWork.OrderRepository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
            return deletedOrder;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await unitOfWork.OrderRepository.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await unitOfWork.OrderRepository.GetByIdAsync(id);
        }

        public async Task<Order> UpdateOrderAsync(Guid id, UpdateOrder order)
        {
            var orderUpdate= await unitOfWork.OrderRepository.GetByIdAsync(id);
            if (orderUpdate != null)
            {
                orderUpdate.OrderQty= order.OrderQty;
                orderUpdate.ShippingAddressID= order.ShippingAddressID;
                orderUpdate.ShippingMethodId= order.ShippingMethodId;

                await unitOfWork.OrderRepository.AddAsync(orderUpdate);
                await unitOfWork.SaveAsync();
            }
            return orderUpdate;
        }

    }
 }
