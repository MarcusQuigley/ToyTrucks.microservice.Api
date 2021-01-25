using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HessTrucks.Web.Models.Api;
using HessTrucks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HessTrucks.Web.Pages.Toys
{
    public class IndexModel : PageModel
    {
        private readonly ITruckCatalogService _truckCatalogService;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Truck> Trucks { get; set; }
        public IndexModel(ITruckCatalogService truckCatalogService, ILogger<IndexModel> logger)
        {
            _truckCatalogService = truckCatalogService;
            _logger = logger;
        }
        public async  Task<IActionResult> OnGet()
        {
            Trucks = await _truckCatalogService.GetTrucksByCategoryId(3);

            var categories = await _truckCatalogService.GetCategoriesBySize(false);
            foreach (var category in categories)
                _logger.LogInformation("Name: {0}, Order: {1}", category.Name, category.Order);
            return Page();
 
        }
    }
}
