using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using EntityLayer.Models;
using OrderingBooking.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingBooking.Data.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
    }
}
