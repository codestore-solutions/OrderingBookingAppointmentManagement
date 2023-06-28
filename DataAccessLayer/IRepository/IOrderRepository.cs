using DataAccessLayer.IRepository;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingBooking.Data.IRepository
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
    }
}
