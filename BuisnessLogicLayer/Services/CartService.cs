using Azure.Core;
using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer.Common;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace BuisnessLogicLayer.Services
{
    public class CartService: ICartService
    {
        private readonly IUnitOfWork unitOfWork;
        public CartService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ResponseDto?> GetCartAsync(long userId)
        {
            // Include Cart navigation property
            var cart = await unitOfWork.CartRepository.GetAll().Include(c => c.CartItems)
           .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return null;
            }
            var response = new ResponseDto
            {
                StatusCode = 200,
                Success = true,
                Data = cart,
                Message = StringConstant.SuccessMessage
            };
            return response;            
        }
        public async Task<ResponseDto> AddToCartAsync(AddToCartRequestDto addToCartRequestDto)
        {
            // check if cart exist or not w.r.t userId
            var cart = unitOfWork.CartRepository.GetAll().Include(c=>c.CartItems).FirstOrDefault(c => c.UserId == addToCartRequestDto.UserId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = addToCartRequestDto.UserId,
                };  
                await unitOfWork.CartRepository.AddAsync(cart);
            }
            
            // check if product already exist in cart or not 
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == addToCartRequestDto.ProductId || ci.VarientId == addToCartRequestDto.VarientId);
            if (cartItem != null)
            {
                // product already exist
                return new ResponseDto()
                {
                    StatusCode  = 400,
                    Success     = false,
                    Data        = cartItem,
                    Message     = StringConstant.ExistMessage
               };
            } else
            {
                cartItem = new CartItems
                {
                    CartId = cart.Id,
                    ProductId = addToCartRequestDto.ProductId,
                    Quantity = addToCartRequestDto.ProductQuantity                  
                };
                cart.CartItems.Add(cartItem);
            }
            bool saveResult = await unitOfWork.SaveAsync();
            // Common Response DTO
            var resonseDto = new ResponseDto()
            {
                StatusCode = saveResult ? 200:400,
                Success = saveResult,
                Message = saveResult ? StringConstant.SuccessMessage: StringConstant.InvalidInputError,
                Data = cartItem
            };
            return resonseDto;
        }
        public async Task DeleteItemFromCartAsync(long productId, long userId)
        {
            var cart = unitOfWork.CartRepository.GetAll().Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userId);
            if (cart != null)
            {
                var itemToBeDeleted = cart.CartItems.FirstOrDefault(p => p.ProductId == productId);
                if (itemToBeDeleted != null)
                {
                    cart.CartItems.Remove(itemToBeDeleted);
                    await unitOfWork.SaveAsync();
                    return;
                }
            }
        }
        public async Task<ResponseDto> UpdateProductQuantityAsync(UpdateProductQtyRequestDto updateProductQtyRequest)
        {
            // Retrieve the cart based on the userId
            var cart = await unitOfWork.CartRepository.GetAll().Include(c => c.CartItems).
                FirstOrDefaultAsync(c => c.UserId == updateProductQtyRequest.UserId);             
            
            // Retrieve product from cart where productId matches within the cart
            var cartItem = cart.CartItems.FirstOrDefault(p=> p.ProductId == updateProductQtyRequest.ProductId);
            if (cartItem != null)
            {
                cartItem.Quantity = updateProductQtyRequest.ProductQuantity;
                await unitOfWork.SaveAsync();
            }            
            var response = new ResponseDto
            {
                StatusCode = 200,
                Success = true,
                Message = StringConstant.SuccessMessage,
                Data = cart
            };
            return response;
        }

    }
}
