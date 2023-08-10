using AutoMapper;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using EntityLayer.Common;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrderingBooking.BL.IServices;
namespace OrderingBooking.BL.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
      
        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseDto> AddAddressAsync(long userId, AddAddressDto addressDto)
        {      
            var addNewAddress = new Address();
            mapper.Map(addressDto, addNewAddress);
            addNewAddress.UserId = userId;

            await unitOfWork.AddressRepository.AddAsync(addNewAddress);
            bool saveResult = await unitOfWork.SaveAsync();            

            return new ResponseDto
            {
                Success         = saveResult,
                StatusCode      = saveResult? 200 : 500,
                Data            = addNewAddress,
                Message         = saveResult? StringConstant.AddressCreatedMessage : StringConstant.DatabaseMessage
            };
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync(long userId)
        {   
            return await unitOfWork.AddressRepository.GetAllAsQueryable().Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<Address?> GetAddressByIdAsync(long shippingAddressId)
        {
            return await unitOfWork.AddressRepository.GetByIdAsync(shippingAddressId);
        }

        public async Task<Address?> DeleteAddressAsync(long addressId)
        {
            var address = await unitOfWork.AddressRepository.DeleteAsync(addressId);
            if (address != null)
            {
               await unitOfWork.SaveAsync();
            }
            return address;
        }

        // Required for Order Processing Module for data mapping.
        public async Task<IEnumerable<Address>> GetMultipleAddressesAsync(List<long> addressIds)
        {
            var addressesList = new List<Address>();

            foreach(var addressId in addressIds)
            {
                var address = await unitOfWork.AddressRepository.GetByIdAsync(addressId);
                if (address != null)
                {
                    addressesList.Add(address);
                }
            }
            return addressesList;
        }

        public async Task<Address?> UpdateAddressAsync(long addressId, UpdateAddressDto addressDto)
        {
            var address = await unitOfWork.AddressRepository.GetByIdAsync(addressId);
            if(address != null) 
            {
                mapper.Map(addressDto, address);
                await unitOfWork.SaveAsync();
            }
            return address;
        }


       /* public async Task<List<string>> GetNearbyAddresses(double latitude, double longitude, int radius = 30)
        {
            var apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&radius={radius}&key={_apiKey}";

            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GeocodingResponse>(content);

            return result?.Results?.ConvertAll(r => r.FormattedAddress);
        }*/
    }

    public class GeocodingResponse
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }
    }
}
