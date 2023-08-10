using Entitites.Dto;
using EntityLayer.Dto;
using EntityLayer.Models;

namespace OrderingBooking.BL.IServices
{
    public interface IOrderService
    {
        public Task<ResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        public Task<IEnumerable<Order>> GetAllOrdersAsync(long userId);
        public Task<ResponseDto> GetOrdersList(List<long> orderIds);
    }
}
