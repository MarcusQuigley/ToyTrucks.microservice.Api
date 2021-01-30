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
    public class EditModel : PageModel
    {
        private readonly ITruckCatalogService _service;
        private readonly ILogger<EditModel> _logger;
        public Truck Truck { get; set; }
        public EditModel(ILogger<EditModel> logger, ITruckCatalogService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> OnGet(Guid truckId)
        {
            if (truckId == Guid.Empty)
                throw new ArgumentNullException(nameof(truckId));

            Truck = await _service.GetTruck(truckId);
            if (Truck != null)
                return Page();
            return RedirectToPage("../NotFound");
        }

        public IActionResult OnPost( ) {
            if (ModelState == null) { }
            //var request = new AddTruckRequest() { Truck = truck };
            //var response = _truckService.AddTruck(request);
            //var request = new UpdateTruckRequest() { Truck = Truck };
            //var response = _truckService.UpdateTruck(request);
            //if (response.Success == Protos.ReadingStatus.Failure)
            //{
            //    _logger.LogError("Error updating truck");
            //    return Page();
            //}
            return RedirectToPage("./Index");
            
         }
        
        
    }
}
