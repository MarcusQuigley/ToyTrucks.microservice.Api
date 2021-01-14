using AutoMapper;
using HessTrucks.Services.TruckCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Mapping
{
    public class PhotosProfile : Profile
    {
        public PhotosProfile()
        {
            CreateMap<Photo, Models.PhotoDto>();
            CreateMap<Models.PhotoDto, Photo>()
                .ReverseMap();
        }
    }
}
