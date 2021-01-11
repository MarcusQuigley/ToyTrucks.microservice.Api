using HessTrucks.Services.TruckCatalog.DbContexts;
using HessTrucks.Services.TruckCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TruckCatalogDbContext _context;

        public CategoryRepository(TruckCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetGategories()
        {
            return await _context.Categories.ToListAsync();
        }        
    }
}
