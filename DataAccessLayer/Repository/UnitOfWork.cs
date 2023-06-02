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
            CartRepository = new CartRepository(dbContext);
            WishListRepository =new WishListRepository(dbContext);
            ProductRepository = new ProductRepository(dbContext);
            CartItemsRepository = new CartItemsRepository(dbContext);
            this.dbContext = dbContext;
        }
        public IOrderRepository OrderRepository
        {
            get;
            private set;
        }

        public IWishListRepository WishListRepository
        {
            get;
            private set;
        }

        public IProductRepository ProductRepository
        {
            get;
            private set;
        }

        public ICartRepository CartRepository
        {
            get;
            private set;
        }

        public ICartItemsRepository CartItemsRepository
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
