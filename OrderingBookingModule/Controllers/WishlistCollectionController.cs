using Entitites.Dto;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.IServices;
using System.ComponentModel.DataAnnotations;

namespace OrderingBooking.API.Controllers
{
    [Route("api/v{version:apiVersion}/wishlist-collection")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WishlistCollectionController : ControllerBase
    {
        private readonly IWishlistCollectionService wishlistCollectionService;

        public WishlistCollectionController(IWishlistCollectionService wishlistCollectionService)
        {
            this.wishlistCollectionService = wishlistCollectionService;
        }

        /// <summary>
        /// Get Wishlist Collection By Id.
        /// </summary>
        /// <param name="wishListCollectionId"></param>
        /// <returns></returns>
        [HttpGet("getCollectionById")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetWishlistCollectionById([FromQuery][Required] long wishListCollectionId)
        {
            var result = await wishlistCollectionService.GetWishlistCollectionById(wishListCollectionId);
            return result == null ? NotFound(new { message = StringConstant.ResourceNotFoundError })
                : Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.SuccessMessage });
        }

        /// <summary>
        /// Add new wishlist collection.
        /// </summary>
        /// <param name="collectionDto"></param>
        /// <returns></returns>
        [HttpPost("add-collection")]
        [ValidateModel]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AddNewCollection(WishlistCollectionDto collectionDto)
        {
            var result = await wishlistCollectionService.AddNewWishlistCollection(collectionDto);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.AddedMessage });
            }
            return StatusCode(500, StringConstant.DatabaseMessage);
        }

        /// <summary>
        /// Get list of all collections for a specific user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("get-all-collections")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllCollectionsName([FromQuery][Required] long userId)
        {
            var result = await wishlistCollectionService.GetAllWishlistCollections(userId);
            if (result.Any())
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.SuccessMessage });
            }
            return NotFound(StringConstant.ResourceNotFoundError);
        }

        /// <summary>
        /// Delete a Wishlist Collection 
        /// </summary>
        /// <param name="wishlistCollectionId"></param>
        /// <returns></returns>
        [HttpDelete]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteCollectionAsync([FromQuery][Required] long wishlistCollectionId)
        {
            var result = await wishlistCollectionService.DeleteCollectionAsync(wishlistCollectionId);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.DeletedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /// <summary>
        /// Update wishlist collection name.
        /// </summary>
        /// <param name="wishlistCollectionId"></param>
        /// <param name="updateCollectionNameDto"></param>
        /// <returns></returns>
        [HttpPut("update-collection-name")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        public async Task<IActionResult> UpdateCollectionNameAsync([FromQuery] long wishlistCollectionId, [FromBody] UpdateCollectionNameDto updateCollectionNameDto)
        {
            var result = await wishlistCollectionService.UpdateCollectionNameAsync(wishlistCollectionId, updateCollectionNameDto);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.UpdatedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

    }
}
