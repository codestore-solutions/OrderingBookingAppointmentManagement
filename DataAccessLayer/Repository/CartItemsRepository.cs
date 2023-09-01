using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using EntityLayer.Models;

namespace DataAccessLayer.Repository
{
    public class CartItemsRepository : GenericRepository<CartItem>, ICartItemsRepository
    {
        public CartItemsRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
