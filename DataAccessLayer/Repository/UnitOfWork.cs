using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using OrderingBooking.Data.IRepository;
using OrderingBooking.Data.Repository;
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
            OrderRepository = new OrderRepository(dbContext);
            WishlistCollectionRepository = new WishlistCollectionRepository(dbContext);
            CartRepository = new CartRepository(dbContext);
            WishListRepository =new WishListRepository(dbContext);
            CartItemsRepository = new CartItemsRepository(dbContext);
            ShippingAddressRepository = new ShippingAddressRepository(dbContext);
            AddressRepository = new AddressRepository(dbContext);
            this.dbContext = dbContext;
        }
        public IWishListRepository WishListRepository
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

        public IShippingAddressRepository ShippingAddressRepository
        {
            get;
            private set;
        }

        public IAddressRepository AddressRepository
        {
            get;
            private set;
        }

        public IWishlistCollectionRepository WishlistCollectionRepository
        {
            get;
            private set;
        }

        public IOrderRepository OrderRepository
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

        public async Task<bool> SaveAsync()
        {
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
