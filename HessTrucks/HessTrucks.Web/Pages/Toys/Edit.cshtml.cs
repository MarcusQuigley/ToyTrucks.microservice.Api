using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HessTrucks.Grpc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessTrucks.Web.Pages.Toys
{
    public class EditModel : PageModel
    {
        private readonly Trucks.TrucksClient _truckService;

        [BindProperty]
        public Truck Truck { get; set; }

        public EditModel(Trucks.TrucksClient truckService)
        {
            _truckService = truckService;
        }
         
        public IActionResult OnGet(string truckId)
        {
            if (!string.IsNullOrEmpty(truckId))
            {
                var request = new GetTruckRequest();
                request.TruckId = truckId;
                var response = _truckService.GetTruckById(request);

                Truck = response.Truck;
                if (response.Truck != null)
                    return Page();
            }
            return RedirectToPage("../NotFound");

        }

        public IActionResult OnPost( ) {
            
            //var request = new AddTruckRequest() { Truck = truck };
            //var response = _truckService.AddTruck(request);
            var request = new UpdateTruckRequest() { Truck = Truck };
            var response = _truckService.UpdateTruck(request);
            return Page();
         }
    }
}
