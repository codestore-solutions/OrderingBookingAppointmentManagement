using Entitites.Dto;
using Entitites.Models;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingBooking.BL.IServices
{
    public interface IWishlistCollectionService
    {
        public Task<WishlistCollection?> GetWishlistCollectionById(long WishListCollectionId);
        public Task<WishlistCollection?> AddNewWishlistCollection(WishlistCollectionDto collectionDto);
        public Task<IEnumerable<WishlistCollection>> GetAllWishlistCollections(long userId);
        public Task<WishlistCollection?> DeleteCollectionAsync(long wishlistCollectionId);
        public Task<WishlistCollection?> UpdateCollectionNameAsync(long wishlistCollectionId, UpdateCollectionNameDto updateCollectionNameDto);

    }
}
