using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using EntityLayer.Models;
using OrderingBooking.Data.IRepository;

namespace OrderingBooking.Data.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
