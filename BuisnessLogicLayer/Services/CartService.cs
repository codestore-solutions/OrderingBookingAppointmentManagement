using Azure.Core;
using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Net.WebSockets;

namespace BuisnessLogicLayer.Services
{
    public class CartService: ICartService
    {
        private readonly IUnitOfWork unitOfWork;
        public CartService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public Cart GetCart(long userId)
        {
            var cart = unitOfWork.CartRepository.Include(c => c.CartItems)                    // Include Cart navigation property
           .FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                return null;
            }
            return cart;            
        }
        public async Task<Cart> AddToCartAsync(AddProductInOrderLine addProductInOrderLine)
        {
            var cart = unitOfWork.CartRepository.AsQueryable().FirstOrDefault(c => c.UserId == addProductInOrderLine.UserId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = addProductInOrderLine.UserId,
                };  
                await unitOfWork.CartRepository.AddAsync(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == addProductInOrderLine.ProductId);
            if (cartItem != null)
            {
                cartItem.Quantity += addProductInOrderLine.ProductQuantity;
            }
            else
            {
                cartItem = new CartItems
                {
                    CartId = cart.Id,
                    ProductId = addProductInOrderLine.ProductId,
                    Quantity = addProductInOrderLine.ProductQuantity                  
                };
                cart.CartItems.Add(cartItem);              
            }
            await unitOfWork.SaveAsync();   
            return cart;
        }
        public async Task<Cart> DeleteItemFromCartAsync(long productId, long userId)
        {
            var cart = unitOfWork.CartRepository.AsQueryable().Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userId);
            if (cart != null)
            {
                var itemToBeDeleted = cart.CartItems.FirstOrDefault(p => p.ProductId == productId);
                if (itemToBeDeleted != null)
                {
                    cart.CartItems.Remove(itemToBeDeleted);
                    await unitOfWork.SaveAsync();
                }
            }
            return cart;
        }
        public async Task<Cart> UpdateProductQuantityAsync(long productId, UpdatePrdouctQuantity updateProduct)
        {
            // Retrieve the cart based on the userId
            var cart = unitOfWork.CartRepository.FindInList(c => c.UserId == updateProduct.UserId);
            if (cart == null)
            {
             // Return null response if the cart is not found
                return null; 
            }
          
            // Update the product quantity
            // left some code
            await unitOfWork.SaveAsync();
            return cart;
        }
    }
}
