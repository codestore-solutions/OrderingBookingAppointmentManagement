using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using EntityLayer;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class WishListRepository : GenericRepository<WishList>,IWishListRepository
    {
        private readonly OrderDbContext dbContext;
        public WishListRepository(OrderDbContext dbContext):base(dbContext) 
        {
            this.dbContext = dbContext;
        }
      /*  public async Task<WishList> AddProductInWishListAsync(AddProductInWishList addProductInWishList)
        {
            var addProduct = new WishList()
            {
                ProductId = addProductInWishList.ProductId,
                UserId = addProductInWishList.UserId,
                Price = addProductInWishList.Price,
                CreatedDateTime = DateTime.Now,
            };
            await dbContext.Wishlists.AddAsync(addProduct);
            await dbContext.SaveChangesAsync();
            return addProduct;
        }
        public async Task<WishList> DeleteProductFromWishListAsync(Guid id)
        {
            var findProdAgainstId = await dbContext.Wishlists.FindAsync(id);
            if (findProdAgainstId != null)
            {
                dbContext.Wishlists.Remove(findProdAgainstId);
                await dbContext.SaveChangesAsync();
            }
            return findProdAgainstId;
        }
        public async Task<List<WishList>> GetAllProductAsync()
        {
            return await dbContext.Wishlists.ToListAsync();
        }*/

    }
}
