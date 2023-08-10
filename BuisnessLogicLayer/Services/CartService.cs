using AutoMapper;
using Azure.Core;
using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer.Common;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Win32.SafeHandles;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace BuisnessLogicLayer.Services
{
    public class CartService: ICartService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync(long userId)
        {
            var cartItems = await unitOfWork.CartItemsRepository.GetAllAsQueryable().Where(c => c.UserId == userId).ToListAsync();
            return cartItems;         
        }
        public async Task<CartItem?> AddToCartAsync(AddToCartRequestDto addToCartRequestDto)
        {
            var cartItem = await unitOfWork.CartItemsRepository.GetAllAsQueryable().FirstOrDefaultAsync(u => 
            u.ProductId == addToCartRequestDto.ProductId
            && u.VariantId == addToCartRequestDto.VariantId
            && u.UserId == addToCartRequestDto.UserId);

            // Product has already added to the cart.
            if(cartItem != null)
            {
                return null;
            }

            var addCartItem = new CartItem();
            mapper.Map(addToCartRequestDto, addCartItem);
            await unitOfWork.CartItemsRepository.AddAsync(addCartItem);
            await unitOfWork.SaveAsync();
            return addCartItem;
        }
        public async Task<CartItem?> DeleteItemFromCartAsync(long cartItemId)
        {
            var deletedItem = await unitOfWork.CartItemsRepository.DeleteAsync(cartItemId);
            if(deletedItem != null)
            {
                await unitOfWork.SaveAsync();
            }
            return deletedItem;
        }
        public async Task<CartItem?> UpdateProductQuantityAsync(UpdateProductQtyRequestDto updateProductQtyRequest)
        {
            var cartItem = await unitOfWork.CartItemsRepository.GetByIdAsync(updateProductQtyRequest.CartItemId);
            if(cartItem != null)
            {
                cartItem.Quantity = updateProductQtyRequest.ProductQuantity;
                await unitOfWork.SaveAsync();
            }
            return cartItem;
        }

    }
}
