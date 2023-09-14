using DataAccessLayer.IRepository;
using EntityLayer.Models;

namespace OrderingBooking.Data.IRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
