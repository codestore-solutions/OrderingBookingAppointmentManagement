using EntityLayer.Dto;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.IServices
{
    public interface ICartService
    {
        public Task<ResponseDto?> GetCartAsync(long userId);
        Task<ResponseDto> AddToCartAsync(AddToCartRequestDto addToCartRequestDto);
        Task<ResponseDto> UpdateProductQuantityAsync(UpdateProductQtyRequestDto updateProduct);
        Task DeleteItemFromCartAsync(long productId, long userId);
    }
}
