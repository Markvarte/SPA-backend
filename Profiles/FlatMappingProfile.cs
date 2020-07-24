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
    public class FlatMappingProfile : Profile
    {
        public FlatMappingProfile()
        { // into profile consructor creates map to transferm 
            // DTOobject into original object and vice versa
            CreateMap<Flat, CreateFlatDTO>();
            CreateMap<CreateFlatDTO, Flat>();
            CreateMap<Flat, FlatVM>()
                .ForMember(
                dest => dest.HouseNum,
                opt => opt.MapFrom(h => h.House.Num))
                .ForMember(
                dest => dest.HouseStreet,
                opt => opt.MapFrom(h => h.House.Street))
                ;
        }
    }
}
