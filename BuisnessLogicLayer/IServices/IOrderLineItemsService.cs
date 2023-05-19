using EntityLayer;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.IServices
{
    public interface IOrderLineItemsService
    {
        Task<IEnumerable<OrderLineItems>> GetAllProductAsync();
        Task<OrderLineItems> AddProductsInOrderLineAsync(AddProductInOrderLine addProductInOrderLine);
        Task<OrderLineItems> UpdateProductQuantityAsync(Guid productId, UpdatePrdouctQuantity updateProduct);
        Task<OrderLineItems> DeleteProductFromOrderLineAsync(Guid productId);
    }
}
