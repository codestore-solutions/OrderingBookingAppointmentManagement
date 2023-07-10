using Entitites.Dto;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingBooking.BL.IServices
{
    public interface IAddressService
    {
       public Task<ResponseDto> GetAllAddressesByUserId(long userId);
       public Task<ResponseDto> GetAddressesInBulkAsync(List<long> shippingAddressIds);
       public Task<ResponseDto> AddNewAddressAsync(long userId, AddNewAddressDto addressDto);
       public Task<ResponseDto?> GetAddressByShippingId(long shippingAddressId);
       public Task<ResponseDto> DeleteAddressAsync(long shippingAddressId);
       public Task<ResponseDto> UpdateAddressAsync(long shippingAddressId, UpdateAddressDto addressDto);

   //    public Task<List<string>> GetNearbyAddresses(double latitude, double longitude, int radius = 30);
    }
}
