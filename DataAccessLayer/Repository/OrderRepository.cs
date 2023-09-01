using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using EntityLayer.Models;
using OrderingBooking.Data.IRepository;

namespace OrderingBooking.Data.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
