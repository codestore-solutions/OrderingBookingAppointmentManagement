using AutoMapper;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using Entitites.Models;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.EntityFrameworkCore;
using OrderingBooking.BL.IServices;
using System.Net.Sockets;

namespace OrderingBooking.BL.Services
{
    public class WishlistCollectionService: IWishlistCollectionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WishlistCollectionService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseDto> GetWishlistCollectionById(long WishListCollectionId)
        {
            var collection = await unitOfWork.WishlistCollectionRepository.GetAll().Include(c=>c.WishlistItems)
            .FirstOrDefaultAsync(u => u.WishlistCollectionId == WishListCollectionId);

            return new ResponseDto
            {
                StatusCode = 200,
                Success = true,
                Data = collection,
                Message = StringConstant.SuccessMessage
            };
        }

        public async Task<ResponseDto> AddNewWishlistCollection(WishlistCollectionDto collectionDto)
        {
            var newWishlistCollection = new WishlistCollection
            {
                UserId = collectionDto.UserId,
                CollectionName = collectionDto.CollectionName,
            };
            await unitOfWork.WishlistCollectionRepository.AddAsync(newWishlistCollection);
            await unitOfWork.SaveAsync();

            return new ResponseDto
            {
                StatusCode = 200,
                Success = true,
                Data = newWishlistCollection,
                Message = StringConstant.SuccessMessage
            };
        }

        public async Task<ResponseDto> GetAllWishlistCollections(long userId)
        {
            var allCollections = await unitOfWork.WishlistCollectionRepository.GetAll().Include("WishlistItems").Where(u => u.UserId == userId).ToListAsync();
            return new ResponseDto
            {
                StatusCode = 200,
                Success = true,
                Data = allCollections,
                Message = StringConstant.SuccessMessage
            };
        }

        public async Task<ResponseDto> DeleteCollectionAsync(long wishlistCollectionId)
        {
            var deletedCollection = await unitOfWork.WishlistCollectionRepository.DeleteAsync(wishlistCollectionId);
            bool saveResult = await unitOfWork.SaveAsync();

            return new ResponseDto
            {
                StatusCode = saveResult ? 200 : 500,
                Success = saveResult,
                Data = deletedCollection,
                Message = saveResult ? StringConstant.SuccessMessage : StringConstant.ErrorMessage
            };
        }

        public async Task<ResponseDto> UpdateCollectionNameAsync(long wishlistCollectionId, UpdateCollectionNameDto updateCollectionNameDto)
        {
            var wishlistCollection = await unitOfWork.WishlistCollectionRepository.GetByIdAsync(wishlistCollectionId);
            if (wishlistCollection == null)
            {
                return new ResponseDto
                {
                    StatusCode = 400,
                    Success = false,
                    Data = StringConstant.InvalidInputError,
                    Message = StringConstant.ErrorMessage
                };
            }
            wishlistCollection.CollectionName = updateCollectionNameDto.CollectionName;
            bool saveResult = await unitOfWork.SaveAsync();
            return new ResponseDto
            {
                StatusCode = saveResult ? 200 : 500,
                Success = saveResult,
                Data = wishlistCollection,
                Message = StringConstant.SuccessMessage
            };
        }

    }
}
