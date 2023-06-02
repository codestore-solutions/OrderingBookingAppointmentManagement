using DataAccessLayer.Data;
using EntityLayer.Models;
using DataAccessLayer.IRepository;

namespace DataAccessLayer.Repository
{ 
    public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(OrderDbContext dbContext) : base(dbContext)
    {
    }
}
}
