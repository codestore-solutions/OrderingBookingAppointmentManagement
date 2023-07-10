using Entitites.Dto;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.IServices;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace OrderingBooking.API.Controllers
{
    [Route("api/v{version:apiVersion}/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Create a new order 
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <returns></returns>
        [HttpPost("create-order")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        public async Task<IActionResult> CreateNewOrderAsync(CreateOrderDto createOrderDto)
        {
            return Ok(await orderService.CreateOrderAsync(createOrderDto));
        }


        /// <summary>
        /// Get all order details by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllOrdersAsync([FromQuery][Required] long userId)
        {
            return Ok(await orderService.GetAllOrdersAsync(userId));
        }


        /// <summary>
        /// Get orders list for multiple orderIds
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        [HttpGet("listOfOrders")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetOrdersList([FromQuery]List<long> orderIds)
        {
            return Ok(await orderService.GetOrdersList(orderIds));
        }
    }
}
