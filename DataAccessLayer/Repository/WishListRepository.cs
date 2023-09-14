using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Entitites.Models;

namespace DataAccessLayer.Repository
{
    public class WishListRepository : GenericRepository<WishlistItems>, IWishListRepository
    {
        private readonly OrderDbContext dbContext;
        public WishListRepository(OrderDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
