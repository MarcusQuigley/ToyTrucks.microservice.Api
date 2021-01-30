using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HessTrucks.Web.Models.Api;
using HessTrucks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HessTrucks.Web.Pages.Trucks
{
    public class IndexModel : PageModel
    {
        private readonly ITruckCatalogService _truckCatalogService;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Truck> Trucks { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(ITruckCatalogService truckCatalogService, ILogger<IndexModel> logger)
        {
            _truckCatalogService = truckCatalogService;
            _logger = logger;
        }
        public async  Task<IActionResult> OnGet()
        {
            Trucks = await _truckCatalogService.GetTrucksByCategoryId(3);

            Categories = await _truckCatalogService.GetCategories();
          
            return Page();
 
        }
    }
}
