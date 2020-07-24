using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2_restAPI.Models;
using Task2_restAPI.ViewModels;

namespace Task2_restAPI.Profiles
{
    // This class is for AutoMapper to map DTOobject into original object and vice versa
    // Creates profile
    public class TenantMappingProfile : Profile
    {
        public TenantMappingProfile()
        { // into profile consructor creates map to transferm 
            // DTOobject and view models objects into original object and vice versa
            CreateMap<Tenant, CreateTenantDTO>();
            CreateMap<CreateTenantDTO, Tenant>();
            CreateMap<Tenant, TenantVM>()
            .ForMember(
                dest => dest.FlatNum,
                opts => opts.MapFrom(f => f.Flat.Num))
            .ForMember(
                dest => dest.HouseId,
                opts => opts.MapFrom(h => h.Flat.HouseId))
            .ForMember(
                dest => dest.HouseNum,
                opts => opts.MapFrom(h => h.Flat.House.Num))
            .ForMember(
                dest => dest.HouseStreet,
                opts => opts.MapFrom(h => h.Flat.House.Street))
            ;
        }
    }
}
