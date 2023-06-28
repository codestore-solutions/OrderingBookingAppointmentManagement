using AutoMapper;
using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using Entitites.Models;
using EntityLayer.Common;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BuisnessLogicLayer.Services
{
    public class WishListService : IWishListService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public WishListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
       
        public async Task<ResponseDto> AddProductsToCollectionAsync(AddProductsToCollectionDto productsToCollectionDto)
        {
            var addNewWishlistItem = new WishlistItems();
            mapper.Map(productsToCollectionDto, addNewWishlistItem);
            await unitOfWork.WishListRepository.AddAsync(addNewWishlistItem);
            bool saveResult = await unitOfWork.SaveAsync();

            return new ResponseDto
            {
                StatusCode = saveResult ? 200 : 500,
                Success = saveResult,
                Data = addNewWishlistItem,
                Message = saveResult ? StringConstant.SuccessMessage : StringConstant.ErrorMessage
            };
        }
        public async Task<ResponseDto> DeleteProductFromWishlistAsync(long wishlistCollectionId, long productId, long? varientId)
        {
            var itemToBeDeleted = await unitOfWork.WishListRepository.GetAll().FirstOrDefaultAsync(p => p.WishListCollectionId == wishlistCollectionId
            && p.ProductId == productId
            && (varientId == null || p.VarientId == varientId));

            if (itemToBeDeleted == null)
            {
                return new ResponseDto
                {
                    StatusCode = 400,
                    Success = false,
                    Data = StringConstant.InvalidInputError,
                    Message = StringConstant.ErrorMessage
                };
            }

            await unitOfWork.WishListRepository.DeleteAsync(itemToBeDeleted.WishlistItemsId);
            bool saveResult = await unitOfWork.SaveAsync();
            return new ResponseDto
            {
                StatusCode = saveResult ? 200 : 500,
                Success = saveResult,
                Data = itemToBeDeleted,
                Message = StringConstant.SuccessMessage
            };
        }
        public async Task<ResponseDto> UpdateProductsQuantityInCollectionAsync(long wishlistCollecttionId, UpdateQuantityDto quantityDto)
        {
            var productItem = await unitOfWork.WishListRepository.GetAll().FirstOrDefaultAsync(u => u.WishListCollectionId == wishlistCollecttionId
            && (quantityDto.VarientId == null || u.VarientId == quantityDto.VarientId)
            && u.ProductId == quantityDto.ProductId);

            if (productItem == null)
            {
                return new ResponseDto
                {
                    StatusCode = 400,
                    Success = false,
                    Data = StringConstant.InvalidInputError,
                    Message = StringConstant.ErrorMessage
                };
            }
            productItem.Quantity = quantityDto.ProductQuantity;
            bool saveResult = await unitOfWork.SaveAsync();

            return new ResponseDto
            {
                StatusCode = saveResult ? 200 : 500,
                Success = saveResult,
                Data = productItem,
                Message = saveResult ? StringConstant.SuccessMessage : StringConstant.ErrorMessage
            };
        }

    }
}
