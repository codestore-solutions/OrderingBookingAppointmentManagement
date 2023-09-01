using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using Entitites.Models;
using OrderingBooking.Data.IRepository;

namespace OrderingBooking.Data.Repository
{
    public class WishlistCollectionRepository : GenericRepository<WishlistCollection>, IWishlistCollectionRepository
    {
        public WishlistCollectionRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
