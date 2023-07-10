using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.IServices;
using OrderingBooking.BL.Services;
using System.ComponentModel.DataAnnotations;

namespace OrderingBooking.API.Controllers
{
    [Route("api/v{version:apiVersion}/wishList")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    //[Authorize]
    public class WishListController : ControllerBase
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
            return Ok(await wishListService.AddProductsToCollectionAsync(productsToCollectionDto));
        }
   
        /// <summary>
        /// Delete a product from wishlist
        /// </summary>
        /// <param name="wishlistCollectionId"></param>
        /// <param name="productId"></param>
        /// <param name="varientId"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteProductFromWishList([FromQuery][Required] long wishlistCollectionId, [FromQuery][Required    ] long productId, [FromQuery] long? varientId)
        {
           return Ok(await wishListService.DeleteProductFromWishlistAsync(wishlistCollectionId, productId, varientId));     
        }

        /// <summary>
        /// Update product quantity in wishlist.
        /// </summary>
        /// <param name="wishlistCollecttionId"></param>
        /// <param name="quantityDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProductsQuantityInCollectionAsync([FromQuery][Required] long wishlistCollecttionId, [FromBody][Required] UpdateQuantityDto quantityDto)
        {
            return Ok(await wishListService.UpdateProductsQuantityInCollectionAsync(wishlistCollecttionId, quantityDto));
        }

    }
}
