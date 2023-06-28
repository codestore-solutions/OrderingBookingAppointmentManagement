using Entitites.Dto;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.IServices;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

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
        /// Get Wishlist Collection By Id
        /// </summary>
        /// <param name="WishListCollectionId"></param>
        /// <returns></returns>
        [HttpGet("getCollectionById")]
        public async Task<IActionResult> GetWishlistCollectionById([FromQuery][Required] long WishListCollectionId)
        {
            return Ok(await wishlistCollectionService.GetWishlistCollectionById(WishListCollectionId));
        }

        /// <summary>
        /// Add New Collection
        /// </summary>
        /// <param name="collectionDto"></param>
        /// <returns></returns>
        [HttpPost("add-collection")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AddNewCollection(WishlistCollectionDto collectionDto)
        {
            return Ok(await wishlistCollectionService.AddNewWishlistCollection(collectionDto));
        }


        [HttpGet("get-all-collections")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllCollectionsName([FromQuery][Required] long userId)
        {
            return Ok(await wishlistCollectionService.GetAllWishlistCollections(userId));
        }


        /// <summary>
        /// Delete a Wishlist Collection 
        /// </summary>
        /// <param name="wishlistCollectionId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCollectionAsync([FromQuery][Required]long wishlistCollectionId)
        {
            return Ok(await wishlistCollectionService.DeleteCollectionAsync(wishlistCollectionId));
        }

  
        [HttpPut("update-collection-name")]
        [ValidateModel]
        public async Task<IActionResult> UpdateCollectionNameAsync([FromQuery] long wishlistCollectionId, [FromBody] UpdateCollectionNameDto nameDto)
        {
            return Ok(await wishlistCollectionService.UpdateCollectionNameAsync(wishlistCollectionId,nameDto)); 
        }

    }
}
