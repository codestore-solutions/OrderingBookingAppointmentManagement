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

        [HttpGet]
        public async Task<ActionResult> GetAllProductInWishList()
        {
            return Ok(await wishListService.GetAllProductAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddProductsInWishList(AddProductInWishList addProductInWishList)
        {
            return Ok(await wishListService.AddProductInWishListAsync(addProductInWishList));
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteProductFromWishList(Guid productId)
        {
            var deletedProduct = await wishListService.DeleteProductFromWishListAsync(productId);
            if (deletedProduct == null)
            {
                return BadRequest("Enter Valid ProductId");
            }
            return Ok(deletedProduct);
        }

    }
}
