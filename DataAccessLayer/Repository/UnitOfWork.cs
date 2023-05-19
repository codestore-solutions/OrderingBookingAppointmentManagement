using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext dbContext;
        public UnitOfWork(OrderDbContext dbContext) 
        {
            OrderRepository=new OrderRepository(dbContext);
            OrderLineRepository = new OrderLineRepository(dbContext);
            WishListRepository=new WishListRepository(dbContext);
            this.dbContext = dbContext;
        }

        public IOrderRepository OrderRepository
        {
            get;
            private set;
        }
        public IOrderLineRepository OrderLineRepository
        {
            get;
            private set;
        }

        public IWishListRepository WishListRepository
        {
            get;
            private set;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
