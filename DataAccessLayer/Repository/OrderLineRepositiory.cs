using DataAccessLayer.Data;
using EntityLayer.Models;
using DataAccessLayer.IRepository;

namespace DataAccessLayer.Repository
{
    public class OrderLineRepository : GenericRepository<OrderLineItems>,IOrderLineRepository
    {
        private readonly OrderDbContext dbContext;
        public OrderLineRepository(OrderDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
