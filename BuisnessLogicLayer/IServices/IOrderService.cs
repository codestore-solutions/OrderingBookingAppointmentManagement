using Entitites.Dto;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingBooking.BL.IServices
{
    public interface IOrderService
    {
        public Task<ResponseDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        public Task<ResponseDto> GetAllOrdersAsync(long userId);
    }
}
