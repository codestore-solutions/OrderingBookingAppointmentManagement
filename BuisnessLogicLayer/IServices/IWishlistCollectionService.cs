using Entitites.Dto;
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
        public Task<ResponseDto> GetWishlistCollectionById(long WishListCollectionId);
        public Task<ResponseDto> AddNewWishlistCollection(WishlistCollectionDto collectionDto);
        public Task<ResponseDto> GetAllWishlistCollections(long userId);
        public Task<ResponseDto> DeleteCollectionAsync(long wishlistCollectionId);
        public Task<ResponseDto> UpdateCollectionNameAsync(long wishlistCollectionId, UpdateCollectionNameDto updateCollectionNameDto);

    }
}
