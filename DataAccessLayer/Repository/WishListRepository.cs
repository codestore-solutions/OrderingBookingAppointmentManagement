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
      

    }
}
