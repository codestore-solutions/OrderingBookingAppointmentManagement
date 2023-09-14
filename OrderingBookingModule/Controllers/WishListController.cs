using BuisnessLogicLayer.IServices;
using Entitites.Dto;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using System.ComponentModel.DataAnnotations;

namespace OrderingBooking.API.Controllers
{
    [Route("api/v{version:apiVersion}/wishList")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    //[Authorize]
    public class WishListController : BaseController
    {
        private readonly IWishListService wishListService;

        public WishListController(IWishListService wishListService)
        {
            this.wishListService = wishListService;
        }

        /// <summary>
        /// Add product into wishlist
        /// </summary>
        /// <param name="productsToCollectionDto"></param>
        /// <returns></returns>
        [HttpPost("add-products")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        public async Task<IActionResult> AddProductsToCollectionAsync(AddProductsToCollectionDto productsToCollectionDto)
        {
            var result = await wishListService.AddProductsToCollectionAsync(productsToCollectionDto);
            if (result != null)
            {
                return Ok(new ResponseDto { Success = true, StatusCode = 200, Data = result, Message = StringConstant.AddedMessage });
            }
            return StatusCode(500, new { message = StringConstant.DatabaseMessage });
        }

        /// <summary>
        /// Delete a product from wishlist.
        /// </summary>
        /// <param name="wishlistItemsId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteProductFromWishList([FromQuery][Required] long wishlistItemsId)
        {
            var result = await wishListService.DeleteProductFromWishlistAsync(wishlistItemsId);
            if (result != null)
            {
                return Ok(new ResponseDto { Success = true, StatusCode = 200, Data = result, Message = StringConstant.DeletedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /// <summary>
        /// Update product quantity in wishlist.
        /// </summary>
        /// <param name="wishlistItemsId"></param>
        /// <param name="quantityDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProductsQuantityInCollectionAsync([FromQuery][Required] long wishlistItemsId, [FromBody][Required] UpdateQuantityDto quantityDto)
        {
            var result = await wishListService.UpdateQuantityAsync(wishlistItemsId, quantityDto);
            if (result != null)
            {
                return Ok(new ResponseDto { Success = true, StatusCode = 200, Data = result, Message = StringConstant.UpdatedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

    }
}
