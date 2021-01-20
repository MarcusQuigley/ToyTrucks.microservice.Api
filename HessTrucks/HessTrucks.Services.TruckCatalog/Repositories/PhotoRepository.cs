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
            //TODO when creating PhotoController make it a child of truck controller 
            //see Building Your First API with ASP.NET Core chap 3 lesson 12
            //https://app.pluralsight.com/course-player?clipId=1323d67f-377a-454d-9487-e2915338a8fa
            return await _context.Photos
                                .Where(p => p.TruckId == truckId)
                                .ToListAsync();
        }
    }
}
