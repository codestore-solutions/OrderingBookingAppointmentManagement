using Entitites.Dto;
using Entitites.Models;

namespace BuisnessLogicLayer.IServices
{
    public interface IWishListService
    {
        public Task<WishlistItems?> AddProductsToCollectionAsync(AddProductsToCollectionDto productsToCollectionDto);
        public Task<WishlistItems?> DeleteProductFromWishlistAsync(long wishlistItemsId);
        public Task<WishlistItems?> UpdateQuantityAsync(long wishlistItemsId, UpdateQuantityDto quantityDto);
    }
}
