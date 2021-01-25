using HessTrucks.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Web.Services
{
  public  interface ITruckCatalogService
    {
        Task<Truck> GetTruck(Guid truckId);
        Task<IEnumerable<Truck>> GetTrucks(Guid truckId);
        Task<IEnumerable<Truck>> GetTrucksByCategoryId(int categoryId);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Category>> GetCategoriesBySize(bool isMini);
        Task<Truck> UpdateTruck(Truck truck);
        Task<Truck> AddTruck(Truck truck);
    }
}
