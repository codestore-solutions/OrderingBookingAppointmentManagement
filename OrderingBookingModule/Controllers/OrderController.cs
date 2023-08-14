using Entitites.Dto;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.IServices;
using System.ComponentModel.DataAnnotations;

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
        /// Create a new order .
        /// </summary>
        /// <param name="createOrderDto"></param>
        /// <returns></returns>
        [HttpPost("create-order")]
        [MapToApiVersion("1.0")]
        [ValidateModel]
        [ServiceFilter(typeof(LoggingActionFilter))]
        public async Task<IActionResult> CreateNewOrderAsync(CreateOrderDto createOrderDto)
        {
            var result = await orderService.CreateOrderAsync(createOrderDto);
            if (result.Any())
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.OrderCreatedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /// <summary>
        /// Get all order details by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        [ServiceFilter(typeof(LoggingActionFilter))]
        public async Task<IActionResult> GetAllOrdersAsync([FromQuery][Required] long userId)
        {
            var result = await orderService.GetAllOrdersAsync(userId);
            if (result.Any())
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.SuccessMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /// <summary>
        /// Get list of orders by orderIds.
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        [HttpGet("listOfOrders")]
        [MapToApiVersion("1.0")]
        [ServiceFilter(typeof(LoggingActionFilter))]
        public async Task<IActionResult> GetOrdersList([FromQuery] List<long> orderIds)
        {
            var result = await orderService.GetOrdersListAsync(orderIds);
            if (result.Any())
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.SuccessMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }
    }
}
