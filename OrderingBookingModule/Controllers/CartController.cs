using BuisnessLogicLayer.IServices;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using OrderingBookingModule.CustomActionFilter;

namespace OrderingBookingModule.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        /// <summary>
        /// Get cart specific to user passing UserId as query parameter
        /// </summary>
        /// <param name="userId" example="1001"> UserId</param>
        /// <returns></returns>
        // GET: /api/cart
        [HttpGet]
        public IActionResult GetCart([FromQuery] long userId)
        {
            var  items = cartService.GetCart(userId);
            if(items == null)
            {
                return NotFound("Cart is empty!!");
            }
            return Ok(items);
        }   

        /// <summary>
        /// Add product to cart
        /// </summary>
        /// <param name="addProductInOrderLine"></param>
        /// <remarks>
        /// Sample Request:
        /// {
        /// "productId": "3001"
        /// "userId": "1001"
        /// "quantity" : 1
        /// }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("add")]
        [ValidateModel]
        public async Task<IActionResult> AddToCartAsync(AddProductInOrderLine addProductInOrderLine)
        {
            var newProduct= await cartService.AddToCartAsync(addProductInOrderLine);
            return Ok(newProduct);
        }

        /// <summary>
        /// Update product quantity inside cart
        /// </summary>
        /// <param name="productId" example="2">ProductId</param>
        /// <param name="updateProduct"></param>
        /// <returns></returns>
        [HttpPut("update")]       
        [ValidateModel]
        public async Task<IActionResult> UpdateOrderLine([FromQuery]long productId, UpdatePrdouctQuantity updateProduct)
        {
                var updatedOrderLine = await cartService.UpdateProductQuantityAsync(productId, updateProduct);
                if (updatedOrderLine == null)
                {
                    return NotFound();
                }
                return Ok(updatedOrderLine);
        }

        /// <summary>
        /// Remove product from cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProductFromOrderLine([FromQuery] long productId , [FromQuery] long userId )
        {
            var deletedProduct= await cartService.DeleteItemFromCartAsync(productId,userId);
            if(deletedProduct==null)
            {
                return NotFound();
            }
            return Ok(deletedProduct);
        }

    }
}
