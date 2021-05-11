using AutoMapper;
using Infrastructure.Models;
using SunProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunProject.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            /*I Config AutoMapper to return ProductBrand.Name & Category as the actually name of the product brand & category instead of the file path.
            In order to do this i have to use an expression that takes a func delegate that returns a bool!*/
            CreateMap<Products, ProductsDTO>()
                .ForMember(p => p.ProductId, m => m.MapFrom(s => s.Id))
                .ForMember(f => f.ProductBrand, m => m.MapFrom(s => s.ProductBrand.Name))
                .ForMember(f => f.Category, m => m.MapFrom(s => s.Category.Name))
                .ForMember(f => f.ImageUrl, m => m.MapFrom<ProductsResolver>());
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
