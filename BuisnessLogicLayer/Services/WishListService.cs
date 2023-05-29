using AutoMapper;
using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer;
using EntityLayer.Dto;
using EntityLayer.Models;
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
        public async Task<WishListResponseDto> AddProductInWishListAsync(AddWishListRequestDto addWishListRequest)
        {
            // Check if the user and product exist\
            // Pending now , We have to fetch data from user and product microservices

            // Validation to check: Do not add duplicate product in wishlist with same user id 
            var checkProductId = unitOfWork.WishListRepository.FindInList(p=>p.ProductId==addWishListRequest.ProductId);
            if (checkProductId != null && addWishListRequest.ProductId == checkProductId.ProductId && checkProductId.UserId == addWishListRequest.UserId)
            {
                return null;
            }
            var newAddedItem = new WishList()
            {
                CreatedDateTime      = DateTime.Now,
               // Price = It'll come from product table 
                ProductId            = addWishListRequest.ProductId,
                UserId               = addWishListRequest.UserId,
            };
            await unitOfWork.WishListRepository.AddAsync(newAddedItem);
            await unitOfWork.SaveAsync();
            return mapper.Map<WishListResponseDto>(newAddedItem);
        }

        public async Task<WishList> DeleteProductFromWishListAsync(Guid productId)
        {          
            var itemToBeDeleted = unitOfWork.WishListRepository.FindInList(p => p.ProductId == productId);
            await unitOfWork.WishListRepository.DeleteAsync(itemToBeDeleted.Id);
            await unitOfWork.SaveAsync();  
            return itemToBeDeleted;
        }

        public async Task<GetWishListResponse> GetAllProductAsync(Guid userId)
        {
            // Get WishList of a specific user through its userId
            var allItems = unitOfWork.WishListRepository.Find((w => w.UserId == userId));
            var getResponseObject = new GetWishListResponse();
            var productIds        = new List<string>();
            foreach (var item in allItems)
            {
                 productIds.Add(item.ProductId.ToString());   
            }
            getResponseObject.ProductIds = productIds;
            return getResponseObject;
        }



    }
}
