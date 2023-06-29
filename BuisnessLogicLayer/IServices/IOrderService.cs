using Entitites.Dto;
using EntityLayer.Dto;

namespace OrderingBooking.BL.IServices
{
    public interface IOrderService
    {
        public Task<ResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        public Task<ResponseDto> GetAllOrdersAsync(long userId);
        public Task<ResponseDto> GetOrdersList(List<long> orderIds);
    }
}
