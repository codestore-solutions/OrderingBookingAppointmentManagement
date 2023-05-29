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

        // GET: /api/wishList/userId/1
        [HttpGet("userId/{id:Guid}")]
        public async Task<ActionResult> GetAllProductInWishList([FromRoute] Guid id)
        {
            return Ok(await wishListService.GetAllProductAsync(id));
        }

        //POST: /api/wishList/addProduct
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProductsInWishList([FromBody] AddWishListRequestDto addWishListRequest)
        {
            var product = await wishListService.AddProductInWishListAsync(addWishListRequest);
            if(product == null)
            {
                return Ok(" Already Added in your WishList ");
            }
            return Ok(product);
        }

        // DELETE : /api/wishList/productId/1
        [HttpDelete("productId/{id}")]
        public async Task<IActionResult> DeleteProductFromWishList([FromRoute] Guid id)
        {
            var deletedProduct = await wishListService.DeleteProductFromWishListAsync(id);
            if (deletedProduct == null)
            {
                return NotFound("productId can't exist");
            }
            return Ok(deletedProduct);
        }

    }
}
