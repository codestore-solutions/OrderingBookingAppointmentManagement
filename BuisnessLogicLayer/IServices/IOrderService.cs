using EntityLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<Order> CreateNewOrderAsync(CreateNewOrder order);
        Task<Order> UpdateOrderAsync(Guid id,UpdateOrder order);
        Task<Order> DeleteOrderAsync(Guid id);
    }
}
