using Entitites.Dto;
using EntityLayer.Models;

namespace OrderingBooking.BL.IServices
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> CreateOrderAsync(CreateOrderDto createOrderDto);
        public Task<IEnumerable<Order>> GetAllOrdersAsync(long userId, int pageNumber, int limit);
        public Task<IEnumerable<Order>> GetOrdersListAsync(List<long> orderIds);
    }
}
