using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace OrderingBookingModule.Controllers
{
    [Route("api/wishList")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService wishListService;

        public WishListController(IWishListService wishListService)
        {
            this.wishListService = wishListService;
        }

        /// <summary>
        /// Get list of all products in wishlist
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        // GET: /api/wishList?userId=1001
        [HttpGet]
        public async Task<ActionResult> GetAllProductsInWishList([FromQuery] long userId)
        {
            return Ok(await wishListService.GetAllProductAsync(userId));
        }

        /// <summary>
        /// Add products into wishlist 
        /// </summary>
        /// <param name="addWishListRequest"></param>
        /// Sample request:
        ///
        ///     POST /api/wishList/add
        ///     {
        ///        "productId"    : long
        ///        "userId"   : long,
        ///     }
        /// </remarks>
        /// <returns></returns>
        //POST: /api/wishList/addItem
        [HttpPost("add")]
        public async Task<IActionResult> AddProductsInWishList([FromBody] AddWishListRequestDto addWishListRequest)
        {
            var product = await wishListService.AddProductInWishListAsync(addWishListRequest);
            if(product == null)
            {
                return Ok(" Already Added in your WishList ");
            }
            return Ok(product);
        }

        /// <summary>
        /// Remove products from wishlist
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        // DELETE : /api/wishList?userId=1001&productId=3001
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProductFromWishList([FromQuery] long userId, [FromQuery] long productId)
        {
            var deletedProduct = await wishListService.DeleteProductFromWishListAsync(userId, productId);
            if (deletedProduct == null)
            {
                return NotFound("productId can't exist");
            }
            return Ok(deletedProduct);
        }

    }
}
