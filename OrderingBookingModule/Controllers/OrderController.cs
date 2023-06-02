using BuisnessLogicLayer.IServices;
using EntityLayer;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace OrderingBookingModule.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            return Ok(await orderService.GetAllOrdersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] long id)
        {
            var order = await orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateNewOrder newOrder)
        {
            await orderService.CreateNewOrderAsync(newOrder);
            return CreatedAtAction(nameof(CreateOrder), newOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(long id,UpdateOrder order)
        {
            var updatedOrder = await orderService.UpdateOrderAsync(id, order);

            if (updatedOrder == null)
            {
                return NotFound();
            }

            return Ok(updatedOrder); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var order=await orderService.DeleteOrderAsync(id);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        } 

    }
}
