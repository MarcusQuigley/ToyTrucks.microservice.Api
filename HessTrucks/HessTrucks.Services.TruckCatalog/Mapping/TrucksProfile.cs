using AutoMapper;
using HessTrucks.Services.TruckCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Mapping
{
    public class TrucksProfile : Profile
    {
        public TrucksProfile()
        {

            CreateMap<Truck, Models.TruckDto>();
            CreateMap<Models.TruckDto, Truck>()
                .ReverseMap();

           //CreateMap<Truck, Models.TruckDto>()
            //   .ForMember(
            //       dto => dto.Categories,
            //       opt => opt.MapFrom(
            //           t => t.TruckCategories.Select(tc => tc.Category)))
            //       ;

            //CreateMap<Models.TruckDto, Truck>()
            //    .ForMember(
            //        t => t.TruckCategories,
            //        opt => opt.MapFrom(dto => dto.TruckCategories))
            //    .AfterMap((dto, model) => {
            //        foreach (var tc in model.TruckCategories)
            //            tc.Truck = model;
            //    });
        }
    }
}
