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
    public class DetailModel : PageModel
    {
        private readonly ITruckCatalogService _service;
        private readonly ILogger<DetailModel> _logger;
        public DetailModel(ITruckCatalogService service, ILogger<DetailModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        public Truck Truck { get; set; }


 

        public async Task<IActionResult> OnGet(Guid truckId)
        {
            if (truckId == Guid.Empty)
                throw new ArgumentNullException(nameof(truckId));
            Truck = await _service.GetTruck(truckId);
            if (Truck != null)
                return Page();
            return RedirectToPage("../NotFound");
        }
    }
}
