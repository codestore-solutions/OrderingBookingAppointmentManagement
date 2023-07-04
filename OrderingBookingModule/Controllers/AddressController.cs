using Entitites.Dto;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingBooking.API.CustomActionFilter;
using OrderingBooking.BL.IServices;

namespace OrderingBooking.API.Controllers
{
    [Route("api/v{version:apiVersion}/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        /// <summary>
        /// Get all addresses of a user by userId
        /// </summary>
        /// <param name="userId" example="5"></param>
        /// <returns></returns>
        [HttpGet("get-all-addresses")]
        public async Task<IActionResult> GetAllAddressesByUserId([FromQuery] long userId)
        {
            return Ok(await addressService.GetAllAddressesByUserId(userId));
        }

        /// <summary>
        /// Get shipping address by userId and shippingId in which product would be delivered.
        /// </summary>
        /// <param name="userId" example="5"></param>
        /// <param name="shippingAddressId" example="1"></param>
        /// <returns></returns>
        [HttpGet("get-address")]
        public async Task<IActionResult> GetAddress([FromQuery] long shippingAddressId)
        {
            return Ok(await addressService.GetAddressByShippingId(shippingAddressId));
        }

        /// <summary>
        /// Used to fetch multiple addresses based on bulk shippingIds
        /// </summary>
        /// <param name="shippingAddressIds"></param>
        /// <returns></returns>
        [HttpGet("getMultipleAddress")]
        public async Task<IActionResult> GetAddressesInBulk([FromQuery] List<long> shippingAddressIds)
        {
            return Ok(await addressService.GetAddressesInBulkAsync(shippingAddressIds));
        }

        /// <summary>
        /// Add new address for a user 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressDto"></param>
        /// <returns></returns>
        [HttpPost("add-address")]
        [ValidateModel]
        public async Task<IActionResult> AddNewAddress([FromQuery] long userId, [FromBody] AddNewAddressDto addressDto)
        {
            return Ok(await addressService.AddNewAddressAsync(userId, addressDto));    
        }

        /// <summary>
        /// Delete a address by userId & shippingAddressId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="shippingAddressId"></param>
        /// <returns></returns>
        [HttpDelete("delete-address")]
        public async Task<IActionResult> DeleteAddressAsync([FromQuery] long shippingAddressId)
        {
            return Ok(await addressService.DeleteAddressAsync(shippingAddressId));
        }

        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> UpdateAddressAsync(long shippingAddressId, UpdateAddressDto addressDto)
        {
            return Ok(await addressService.UpdateAddressAsync(shippingAddressId, addressDto));
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
