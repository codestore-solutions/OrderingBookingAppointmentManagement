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


        [HttpPost("add-products")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        public async Task<IActionResult> AddProductsToCollectionAsync(AddProductsToCollectionDto productsToCollectionDto)
        {
            return Ok(await wishListService.AddProductsToCollectionAsync(productsToCollectionDto));
        }
   
        [HttpDelete("delete")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteProductFromWishList([FromQuery][Required] long wishlistCollectionId, [FromQuery][Required    ] long productId, [FromQuery] long? varientId)
        {
           return Ok(await wishListService.DeleteProductFromWishlistAsync(wishlistCollectionId, productId, varientId));     
        }

        [HttpPut("update")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        public async Task<IActionResult> UpdateProductsQuantityInCollectionAsync([FromQuery][Required] long wishlistCollecttionId, [FromBody][Required] UpdateQuantityDto quantityDto)
        {
            return Ok(await wishListService.UpdateProductsQuantityInCollectionAsync(wishlistCollecttionId, quantityDto));
        }

    }
}
