using BuisnessLogicLayer.IServices;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;

namespace OrderingBooking.API.Controllers
{
    [Route("api/v{version:apiVersion}/cart")]
    [ApiController]
    [ApiVersion("1.0")]
    //[Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        // GET: /api/cart
        /// <summary>
        /// Get cart by userId
        /// </summary>
        /// <param name="userId" example="1001"> UserId</param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetCartAsync([FromQuery] long userId)
        {
            var cart = await cartService.GetCartAsync(userId);
            if (cart == null)
            {
                return NotFound(StringConstant.EmptyMessage);
            }
            return Ok(cart);
        }

        // POST: /api/cart/add
        /// <summary>
        /// Add product to cart
        /// </summary>
        /// <param name="addToCartRequest"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/cart/add
        ///     {
        ///        "productId"       : long,
        ///        "varientId"       : long,
        ///        "userId"          : long,
        ///        "productQuantity" : int
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("add")]
        [ValidateModel]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AddToCartAsync(AddToCartRequestDto addToCartRequest)
        {
            return Ok(await cartService.AddToCartAsync(addToCartRequest));
        }

        // PUT: /api/cart/updateQty
        /// <summary>
        /// Update product quantity inside cart
        /// </summary>
        /// <param name="productId" example="2">ProductId</param>
        /// <param name="updateProduct"></param>
        /// <returns></returns>
        [HttpPut("updateQty")]
        [ValidateModel]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateOrderLine(UpdateProductQtyRequestDto updateProduct)
        {
            var updatedOrderLine = await cartService.UpdateProductQuantityAsync(updateProduct);
            if (updatedOrderLine == null)
            {
                return NotFound(StringConstant.InvalidInputError);
            }
            return Ok(updatedOrderLine);
        }

        // DELETE: /api/cart/delete
        /// <summary>
        /// Remove product from cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteProductFromOrderLine([FromQuery] long productId, [FromQuery] long userId)
        {
            await cartService.DeleteItemFromCartAsync(productId, userId);
            return Ok(StringConstant.SuccessMessage);
        }



    }
}
