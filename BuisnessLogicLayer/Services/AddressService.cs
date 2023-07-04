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
using System.Net.Http;

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

        public async Task<ResponseDto> AddNewAddressAsync(long userId, AddNewAddressDto addressDto)
        {
            var shippingAddresss = unitOfWork.ShippingAddressRepository.GetAll().Include(c => c.Addresss).FirstOrDefault(c => c.UserId == userId);
            if (shippingAddresss == null)
            {
                shippingAddresss = new ShippingAddress
                {
                    UserId = userId,
                };
                await unitOfWork.ShippingAddressRepository.AddAsync(shippingAddresss);
            }           
                var newAddress = new Address();                                       
                newAddress = mapper.Map<Address>(addressDto);                         
                newAddress.ShippingAddressId = shippingAddresss.ShippingAddressId;   // foreign key relation
                shippingAddresss.Addresss.Add(newAddress);
                await unitOfWork.SaveAsync();            

            return new ResponseDto
            {
                Success = true,
                StatusCode = 200,
                Data = shippingAddresss,
                Message = StringConstant.SuccessMessage
            };
        }
        public async Task<ResponseDto> GetAllAddressesByUserId(long userId)
        {
            var addresses = await unitOfWork.ShippingAddressRepository.GetAll().Include(c => c.Addresss).Where(u => u.UserId == userId).ToListAsync();
            return new ResponseDto
            {
                Success = true,
                StatusCode = 200,
                Data = addresses,
                Message = StringConstant.SuccessMessage
            };
        }
        public async Task<ResponseDto> GetAddressByShippingId(long shippingAddressId)
        {
            var shippingAddress = await unitOfWork.AddressRepository.GetAll().FirstOrDefaultAsync(u => u.Id == shippingAddressId);
            if(shippingAddress == null)
            {
                return new ResponseDto
                {
                    StatusCode = 400,
                    Success = false,
                    Data = StringConstant.InvalidInputError,
                    Message = StringConstant.ErrorMessage
                };
            }
            return new ResponseDto
            {
                Success = true,
                StatusCode = 200,
                Data = shippingAddress,
                Message = StringConstant.SuccessMessage
            };
        }
        public async Task<ResponseDto> DeleteAddressAsync(long shippingAddressId)
        {
            var address = await unitOfWork.AddressRepository.GetAll().FirstOrDefaultAsync(u => u.Id == shippingAddressId);
            if (address == null)
            {
                return new ResponseDto
                {
                    StatusCode = 400,
                    Success = false,
                    Data = StringConstant.InvalidInputError,
                    Message = StringConstant.ErrorMessage
                };
            }
            unitOfWork.AddressRepository.Delete(address);
            await unitOfWork.SaveAsync();
            return new ResponseDto
            {
                Success = true,
                StatusCode = 200,
                Data = address,
                Message = StringConstant.SuccessMessage
            };

        }
        public async Task<ResponseDto> GetAddressesInBulkAsync(List<long> shippingAddressIds)
        {
            var shippingAddresses = new List<Object>();

            foreach(var shippingAddressId in shippingAddressIds)
            {
                var shippingAddress = await unitOfWork.AddressRepository.GetAll().FirstOrDefaultAsync(u => u.Id == shippingAddressId);
                if (shippingAddress == null)
                {
                    return new ResponseDto
                    {
                        StatusCode = 400,
                        Success = false,
                        Data = StringConstant.InvalidInputError,
                        Message = StringConstant.ErrorMessage
                    };
                }
                shippingAddresses.Add(shippingAddress);
            }
           
            
            return new ResponseDto
            {
                Success = true,
                StatusCode = 200,
                Data = shippingAddresses,
                Message = StringConstant.SuccessMessage
            };

        }
        public async Task<ResponseDto> UpdateAddressAsync(long shippingAddressId, UpdateAddressDto addressDto)
        {
            var address = await unitOfWork.AddressRepository.GetAll().FirstOrDefaultAsync(u => u.Id == shippingAddressId);
            if (address == null)
            {
                return new ResponseDto
                {
                    StatusCode = 400,
                    Success = false,
                    Data = StringConstant.InvalidInputError,
                    Message = StringConstant.ErrorMessage
                };
            }
            mapper.Map(addressDto, address);
            await unitOfWork.SaveAsync();
            return new ResponseDto
            {
                Success = true,
                StatusCode = 200,
                Data = address,
                Message = StringConstant.SuccessMessage
            };
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
