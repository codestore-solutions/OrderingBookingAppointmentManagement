using AutoMapper;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using OrderingBooking.BL.IServices;

namespace OrderingBooking.BL.Services
{
    public class WishlistCollectionService : IWishlistCollectionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WishlistCollectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<WishlistCollection?> GetWishlistCollectionById(long wishListCollectionId)
        {
            var wishlistCollection = await unitOfWork.WishlistCollectionRepository.GetAsQueryable()
            .FirstOrDefaultAsync(u => u.WishlistCollectionId == wishListCollectionId);

            // Lazy Loading 
            if (wishlistCollection != null)
            {
                var wishlistItems = wishlistCollection.WishlistItems;
            }
            return wishlistCollection;
        }

        public async Task<WishlistCollection?> AddNewWishlistCollection(WishlistCollectionDto collectionDto)
        {
            var newWishlistCollection = new WishlistCollection
            {
                UserId = collectionDto.UserId,
                CollectionName = collectionDto.CollectionName,
            };
            await unitOfWork.WishlistCollectionRepository.AddAsync(newWishlistCollection);
            bool saveResult = await unitOfWork.SaveAsync();

            return saveResult ? newWishlistCollection : null;
        }

        public async Task<IEnumerable<WishlistCollection>> GetAllWishlistCollections(long userId)
        {
            var allCollections = await unitOfWork.WishlistCollectionRepository.GetAsQueryable().Include("WishlistItems").Where(u => u.UserId == userId).ToListAsync();
            return allCollections;
        }

        public async Task<WishlistCollection?> DeleteCollectionAsync(long wishlistCollectionId)
        {
            var deletedCollection = await unitOfWork.WishlistCollectionRepository.DeleteAsync(wishlistCollectionId);
            if (deletedCollection != null)
            {
                await unitOfWork.SaveAsync();
            }
            return deletedCollection;
        }

        public async Task<WishlistCollection?> UpdateCollectionNameAsync(long wishlistCollectionId, UpdateCollectionNameDto updateCollectionNameDto)
        {
            var wishlistCollection = await unitOfWork.WishlistCollectionRepository.GetByIdAsync(wishlistCollectionId);
            if (wishlistCollection != null)
            {
                wishlistCollection.CollectionName = updateCollectionNameDto.CollectionName;
                await unitOfWork.SaveAsync();
            }
            return wishlistCollection;
        }

    }
}
