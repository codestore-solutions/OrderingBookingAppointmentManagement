using AutoMapper;
using Entitites.Dto;
using Entitites.Models;
using EntityLayer.Dto;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddNewAddressDto, Address>().ReverseMap();
            CreateMap<UpdateAddressDto, Address>().ReverseMap();    
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<OrderItemsDto, OrderItems>().ReverseMap();
        }
    }
}
