using EntityLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.IServices
{
    public interface ICartService
    {
        Cart GetCart(long userId);
        Task<Cart> AddToCartAsync(AddProductInOrderLine addProductInOrderLine);
        Task<Cart> UpdateProductQuantityAsync(long productId, UpdatePrdouctQuantity updateProduct);
        Task<Cart> DeleteItemFromCartAsync(long productId, long userId);
    }
}
