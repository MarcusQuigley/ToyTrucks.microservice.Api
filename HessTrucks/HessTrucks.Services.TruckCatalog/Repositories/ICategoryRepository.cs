using HessTrucks.Services.TruckCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Category>> GetCategoriesBySize(bool isMini = false);
    }
}
