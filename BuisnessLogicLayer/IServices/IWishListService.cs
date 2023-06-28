using Entitites.Dto;
using EntityLayer.Dto;
using EntityLayer.Models;

namespace BuisnessLogicLayer.IServices
{
    public interface IWishListService
    {
        public Task<ResponseDto> AddProductsToCollectionAsync(AddProductsToCollectionDto productsToCollectionDto);
        public Task<ResponseDto> DeleteProductFromWishlistAsync(long wishlistCollectionId, long productId, long? varientId);
        public Task<ResponseDto> UpdateProductsQuantityInCollectionAsync(long wishlistCollecttionId, UpdateQuantityDto quantityDto);
    }
}
