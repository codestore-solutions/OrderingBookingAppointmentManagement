using EntityLayer;
using EntityLayer.Models;

namespace BuisnessLogicLayer.IServices
{
    public interface IWishListService
    {
        Task<IEnumerable<WishList>> GetAllProductAsync();
        Task<WishList> AddProductInWishListAsync(AddProductInWishList wishList);
        Task<WishList> DeleteProductFromWishListAsync(Guid id);
    }
}
