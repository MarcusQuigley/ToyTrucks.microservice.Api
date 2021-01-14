using AutoMapper;
using HessTrucks.Services.TruckCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Mapping
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, Models.CategoryDto>();
            CreateMap<Models.CategoryDto, Category>()
                .ReverseMap();
        }
    }
}
