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

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesBySize(bool isMini = false)
        {
            return await _context.Categories
                            .Where(c=>c.IsMiniTruck == isMini)
                            .ToListAsync();
        }
    }
}
