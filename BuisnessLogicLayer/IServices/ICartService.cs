using EntityLayer.Dto;
using EntityLayer.Models;

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
