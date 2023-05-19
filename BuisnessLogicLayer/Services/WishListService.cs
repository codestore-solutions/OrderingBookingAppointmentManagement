using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services
{
    public class WishListService : IWishListService
    {
        private readonly IUnitOfWork unitOfWork;

        public WishListService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<WishList> AddProductInWishListAsync(AddProductInWishList wishList)
        {
            var newAddedItem = new WishList()
            {
                CreatedDateTime = DateTime.Now,
                Price = wishList.Price,
                ProductId = wishList.ProductId,
                UserId = wishList.UserId,
            };
            await unitOfWork.WishListRepository.AddAsync(newAddedItem);
            await unitOfWork.SaveAsync();
            return newAddedItem;
        }

        public async Task<WishList> DeleteProductFromWishListAsync(Guid id)
        {
            var deletedItem = await unitOfWork.WishListRepository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
            return deletedItem;
        }

        public async Task<IEnumerable<WishList>> GetAllProductAsync()
        {
            return await unitOfWork.WishListRepository.GetAllAsync();
        }
    }
}
