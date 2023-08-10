using BuisnessLogicLayer.IServices;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.Services;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

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

        /// <summary>
        /// Get all cart items by user id.
        /// </summary>
        /// <param name="userId" example="1001"> UserId</param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseDto>> GetCartAsync([FromQuery][Required] long userId)
        {
            var result = await cartService.GetAllCartItemsAsync(userId);
            if (result.Any())
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result , Message = StringConstant.SuccessMessage});
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError});
        }

        /// <summary>
        /// Add items to cart.
        /// </summary>
        /// <param name="addToCartRequestDto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ValidateModel]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ResponseDto>> AddToCartAsync(AddToCartRequestDto addToCartRequestDto)
        {
            var result = await cartService.AddToCartAsync(addToCartRequestDto);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.AddedToCartMessage});
            }
            return BadRequest(new {message = StringConstant.AlreadyExistMessage});
        }

        /// <summary>
        /// Update item quantity .
        /// </summary>
        /// <param name="updateProductDto"></param>
        /// <returns></returns>
        [HttpPut("updateQty")]
        [ValidateModel]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateQuantityAsync(UpdateProductQtyRequestDto updateProductDto)
        {
            var result = await cartService.UpdateProductQuantityAsync(updateProductDto);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.QuanitityUpdatedMessage});
            }
            return NotFound(new {message = StringConstant.ResourceNotFoundError});
        }

        /// <summary>
        /// Remove item from cart.
        /// </summary>
        /// <param name="cartItemId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteProductFromOrderLine([FromQuery][Required] long cartItemId)
        {
            var result = await cartService.DeleteItemFromCartAsync(cartItemId);
            if(result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.ItemRemovedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /*[HttpDelete("deleteItems/{userId}")]
        public async IActionResult DeleteCartItems(long userId)
        {
            // Delete cart items for the specified user
           var result =  await cartService.DeleteCartItems(userId);

            return Ok(new { message = "Cart items deleted successfully." });
        }*/


    }
}
