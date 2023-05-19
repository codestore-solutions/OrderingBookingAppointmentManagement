using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using EntityLayer.Models;

namespace DataAccessLayer.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly OrderDbContext dbContext;

        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
