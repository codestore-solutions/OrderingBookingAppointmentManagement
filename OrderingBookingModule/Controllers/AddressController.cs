using Entitites.Dto;
using EntityLayer.Common;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.IServices;
using System.ComponentModel.DataAnnotations;

namespace OrderingBooking.API.Controllers
{
    [Route("api/v{version:apiVersion}/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IAddressService addressService, ILogger<AddressController> _logger)
        {
            this.addressService = addressService;
            this._logger = _logger;
        }

        /// <summary>
        /// Get all addresses of a user by userId
        /// </summary>
        /// <param name="userId" example="5"></param>
        /// <returns></returns>
        [HttpGet("get-all-addresses")]
        public async Task<IActionResult> GetAllAddressesByUserId([FromQuery][Required] long userId)
        {
            var result = await addressService.GetAllAddressesAsync(userId);
            if (result.Any())
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.SuccessMessage });
            }
            return NotFound(new { message = StringConstant.NoSavedAddressMessage });
        }

        /// <summary>
        /// Get Address by addressId.
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        [HttpGet("get-address")]
        public async Task<IActionResult> GetAddress([FromQuery][Required] long addressId)
        {
            var result = await addressService.GetAddressByIdAsync(addressId);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.SuccessMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /// <summary>
        /// Used to fetch multiple addresses based on bulk shippingIds
        /// </summary>
        /// <param name="shippingAddressIds"></param>
        /// <returns></returns>
        [HttpGet("getMultipleAddress")]
        public async Task<IActionResult> GetAddressesInBulk([FromQuery] List<long> shippingAddressIds)
        {
            var result = await addressService.GetMultipleAddressesAsync(shippingAddressIds);
            if (result.Any())
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.SuccessMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /// <summary>
        /// Add new address for a user / Add more multiple addresses for same user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressDto"></param>
        /// <returns></returns>
        [HttpPost("add-address")]
        [ValidateModel]
        public async Task<ActionResult<ResponseDto>> AddAddressAsync([FromQuery][Required] long userId, [FromBody][Required] AddAddressDto addressDto)
        {
            var result = await addressService.AddAddressAsync(userId, addressDto);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.AddressCreatedMessage });
            }
            return BadRequest(new { message = StringConstant.InvalidInputError });
        }

        /// <summary>
        /// Delete address by addressId.
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        [HttpDelete("delete-address")]
        public async Task<IActionResult> DeleteAddressAsync([FromQuery][Required] long addressId)
        {
            var result = await addressService.DeleteAddressAsync(addressId);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.AddressDeletedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }

        /// <summary>
        /// Update Address API.
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="addressDto"></param>
        /// <returns></returns>
        [HttpPut("update-address")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAddressAsync([FromQuery][Required] long addressId, UpdateAddressDto addressDto)
        {
            var result = await addressService.UpdateAddressAsync(addressId, addressDto);
            if (result != null)
            {
                return Ok(new ResponseDto { StatusCode = 200, Success = true, Data = result, Message = StringConstant.AddressUpdatedMessage });
            }
            return NotFound(new { message = StringConstant.ResourceNotFoundError });
        }


        /*   [HttpGet("nearby")]
           public async Task<IActionResult> GetNearbyAddresses(double latitude, double longitude)
           {
               try
               {
                   var nearbyAddresses = await addressService.GetNearbyAddresses(latitude, longitude);
                   return Ok(nearbyAddresses);
               }
               catch (Exception ex)
               {
                   // Handle exceptions
                   return StatusCode(500, ex.Message);
               }
           }*/
    }
}
