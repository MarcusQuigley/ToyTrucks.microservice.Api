using HessTrucks.Services.TruckCatalog.DbContexts;
using HessTrucks.Services.TruckCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckCatalogDbContext _context;

        public TruckRepository(TruckCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Truck> GetTruckById(Guid truckId)
        {
            var truck = await _context.Trucks
                                  .Include(t=>t.Photos)
                                  .Where(t => t.TruckId == truckId)
                                  .FirstOrDefaultAsync();
            return truck;                                       
        }

        public async Task<IEnumerable<Truck>> GetTrucks()
        {
            return await _context.Trucks
                                    .Include(t => t.Photos)
                                    .ToListAsync();

        }
    }
}
