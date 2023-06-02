using EntityLayer;
using EntityLayer.Dto;
using EntityLayer.Models;

namespace BuisnessLogicLayer.IServices
{
    public interface IWishListService
    {
        Task<GetWishListResponse> GetAllProductAsync(long userId);
        Task<WishListResponseDto> AddProductInWishListAsync(AddWishListRequestDto wishList);
        Task<WishList> DeleteProductFromWishListAsync(long userId, long productId);
    }
}
