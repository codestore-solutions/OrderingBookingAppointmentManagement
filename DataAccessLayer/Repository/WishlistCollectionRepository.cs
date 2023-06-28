using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using Entitites.Models;
using OrderingBooking.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingBooking.Data.Repository
{
    public class WishlistCollectionRepository : GenericRepository<WishlistCollection>, IWishlistCollectionRepository
    {
        public WishlistCollectionRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
