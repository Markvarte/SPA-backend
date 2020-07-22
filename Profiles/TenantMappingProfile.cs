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
            // DTOobject into original object and vice versa
            CreateMap<Tenant, CreateTenantDTO>();
            CreateMap<CreateTenantDTO, Tenant>();
            CreateMap<Tenant, TenantVM>()
            .ForMember(
                dest => dest.HouseId,
                opts => opts.MapFrom(h => h.Flat.HouseId)
                );
        }
    }
}
