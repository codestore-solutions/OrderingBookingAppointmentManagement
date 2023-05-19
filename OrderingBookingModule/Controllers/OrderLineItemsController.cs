using BuisnessLogicLayer.IServices;
using DataAccessLayer.IRepository;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using OrderingBookingModule.CustomActionFilter;

namespace OrderingBookingModule.Controllers
{
    [Route("api/orderLineItems")]
    [ApiController]
    public class OrderLineItemsController : ControllerBase
    {
        private readonly IOrderLineItemsService orderLineItemsService;
        public OrderLineItemsController(IOrderLineItemsService orderLineItemsService)
        {
            this.orderLineItemsService = orderLineItemsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductInsideOrderLine()
        {
            var allProductsInsideOrderLine = await orderLineItemsService.GetAllProductAsync();
           // throw new Exception("This is a error");
            return Ok(allProductsInsideOrderLine);
        }   

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddingProductsInOrderLine(AddProductInOrderLine addProductInOrderLine)
        {
            var newProduct= await orderLineItemsService.AddProductsInOrderLineAsync(addProductInOrderLine);
            return Ok(newProduct);
        }

        [HttpPut]       
        [Route("{productId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateOrderLine([FromRoute]Guid productId, UpdatePrdouctQuantity updateProduct)
        {
                var updatedOrderLine = await orderLineItemsService.UpdateProductQuantityAsync(productId, updateProduct);
                if (updatedOrderLine == null)
                {
                    return NotFound();
                }
                return Ok(updatedOrderLine);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteProductFromOrderLine([FromRoute]Guid productId)
        {
            var deletedProduct= await orderLineItemsService.DeleteProductFromOrderLineAsync(productId);
            if(deletedProduct==null)
            {
                return NotFound();
            }
            return Ok(deletedProduct);
        }

    }
}
