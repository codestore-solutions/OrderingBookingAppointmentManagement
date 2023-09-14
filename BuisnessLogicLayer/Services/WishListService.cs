using AutoMapper;
using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using Entitites.Models;

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
        public async Task<WishlistItems?> AddProductsToCollectionAsync(AddProductsToCollectionDto productsToCollectionDto)
        {
            var addNewWishlistItem = new WishlistItems();
            mapper.Map(productsToCollectionDto, addNewWishlistItem);
            addNewWishlistItem.CreatedOn = DateTime.Now;
            await unitOfWork.WishListRepository.AddAsync(addNewWishlistItem);
            bool saveResult = await unitOfWork.SaveAsync();

            return saveResult ? addNewWishlistItem : null;
        }
        public async Task<WishlistItems?> DeleteProductFromWishlistAsync(long wishlistItemsId)
        {
            var itemToBeDeleted = await unitOfWork.WishListRepository.DeleteAsync(wishlistItemsId);
            if (itemToBeDeleted != null)
            {
                await unitOfWork.SaveAsync();
            }
            return itemToBeDeleted;
        }
        public async Task<WishlistItems?> UpdateQuantityAsync(long wishlistItemsId, UpdateQuantityDto quantityDto)
        {
            var wishlistItem = await unitOfWork.WishListRepository.GetByIdAsync(wishlistItemsId);
            if (wishlistItem != null)
            {
                wishlistItem.Quantity = quantityDto.Quantity;
                await unitOfWork.SaveAsync();
            }
            return wishlistItem;
        }
    }
}
