﻿
using OrderingBooking.Data.IRepository;

namespace DataAccessLayer.IRepository
{
    public interface IUnitOfWork: IDisposable
    { 
        public IOrderRepository OrderRepository { get; }
        public IWishlistCollectionRepository WishlistCollectionRepository { get; }
        public IAddressRepository AddressRepository { get; }
        public IShippingAddressRepository ShippingAddressRepository { get; }
        public ICartItemsRepository CartItemsRepository { get; }
        public IWishListRepository WishListRepository { get; }
        public ICartRepository CartRepository { get; }
        public void Save();
        public Task<bool> SaveAsync();
    }
}
