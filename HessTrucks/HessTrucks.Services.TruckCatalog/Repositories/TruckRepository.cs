using HessTrucks.Services.TruckCatalog.DbContexts;
using HessTrucks.Services.TruckCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly TruckCatalogDbContext _context;
        private readonly ILogger<TruckRepository> _logger;
        public TruckRepository(TruckCatalogDbContext context, ILogger<TruckRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Truck> GetTruckById(Guid truckId)
        {
            
            var truck = await _context.Trucks
                                  .Include(t => t.Photos)
                                  .Where(t => t.TruckId == truckId)
                                  .FirstOrDefaultAsync();
            if (truck != null)
                _logger.LogDebug("Received a truck with id of {truckId}",truckId);
            return truck;
        }

        public async Task<IEnumerable<Truck>> GetTrucksByCategoryId(int categoryId)
        {
            try
            {
                var trucks = await _context.Trucks
                             .Include(t => t.Photos)
                             .Include(t => t.Categories.Where(c => c.CategoryId == categoryId))
                             .ToListAsync();
              
                return trucks;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occured when loading Trucks data");
            }
            return Array.Empty<Truck>();
        }

        public async Task<IEnumerable<Truck>> GetTrucks()
        {
            return await _context.Trucks
                            .Include(t => t.Photos)
                            .ToListAsync();

        }
    }
}
