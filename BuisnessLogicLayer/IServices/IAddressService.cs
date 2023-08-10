using Entitites.Dto;
using EntityLayer.Dto;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingBooking.BL.IServices
{
    public interface IAddressService
    {
       public Task<IEnumerable<Address>> GetAllAddressesAsync(long userId);
       public Task<IEnumerable<Address>> GetMultipleAddressesAsync(List<long> addressIds);
       public Task<Address> AddAddressAsync(long userId, AddAddressDto addressDto);
       public Task<Address?> GetAddressByIdAsync(long addressId);
       public Task<Address?> DeleteAddressAsync(long addressId);
       public Task<Address?> UpdateAddressAsync(long addressId, UpdateAddressDto addressDto);

   //    public Task<List<string>> GetNearbyAddresses(double latitude, double longitude, int radius = 30);
    }
}
