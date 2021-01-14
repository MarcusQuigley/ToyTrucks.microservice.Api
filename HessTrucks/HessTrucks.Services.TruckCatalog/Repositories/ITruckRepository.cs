using HessTrucks.Services.TruckCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetTrucks();
        Task<IEnumerable<Truck>> GetTrucksByCategoryId(int categoryId);
        Task<Truck> GetTruckById(Guid truckId);
        
    }
}
