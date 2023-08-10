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
        public Task<IEnumerable<CartItem>> GetAllCartItemsAsync(long userId);
        public Task<CartItem?> AddToCartAsync(AddToCartRequestDto addToCartRequestDto);
        public Task<CartItem?> UpdateProductQuantityAsync(UpdateProductQtyRequestDto updateProduct);
        public Task<CartItem?> DeleteItemFromCartAsync(long cartItemId);
    }
}
