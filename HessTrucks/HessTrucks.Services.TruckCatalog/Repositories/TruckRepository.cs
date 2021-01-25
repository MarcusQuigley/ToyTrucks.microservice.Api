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
                _logger.LogDebug("Received a truck with id of {truckId}", truckId);
            return truck;
        }

        public async Task<IEnumerable<Truck>> GetTrucksByCategoryId(int categoryId)
        {
            try
            {
                var trucks = await _context.Trucks
                             .Where(t => t.Categories.Any(c => c.CategoryId == categoryId))
                             .Include(t => t.Photos)
                             .Include(t => t.Categories)
                             .AsSplitQuery()
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

        public async Task AddTruck(Truck truck)
        {
            if (truck == null)
                throw new ArgumentNullException(nameof(truck));

            await _context.Trucks.AddAsync(truck);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task<bool> SaveChanges()
        {
            var save = await _context.SaveChangesAsync();
            return save >= 0;
            //return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateTruck(Truck truck)
        {
            var entity = _context.Trucks.Attach(truck);
            entity.State = EntityState.Modified;

        }
    }
}
