using AutoMapper;
using DataAccessLayer.IRepository;
using Entitites.Dto;
using EntityLayer.Common;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
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

    }
}
