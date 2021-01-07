using HessTrucks.Services.TruckCatalog.DbContexts;
using HessTrucks.Services.TruckCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly TruckCatalogDbContext _context;

        public PhotoRepository(TruckCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotosById(Guid truckId)
        {
            return await _context.Photos
                                .Where(p => p.TruckId == truckId)
                                .ToListAsync();
        }
    }
}
