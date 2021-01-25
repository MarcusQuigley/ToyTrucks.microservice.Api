using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HessTrucks.Web.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HessTrucks.Web.Pages.Toys
{
    public class EditModel : PageModel
    {
  
        private readonly ILogger<EditModel> _logger;
        public Truck Truck { get; set; }
        public EditModel(  ILogger<EditModel> logger)
        {
           
            _logger = logger;
        }
         
        public IActionResult OnGet(string truckId)
        {
            if (!string.IsNullOrEmpty(truckId))
            {
                //var request = new GetTruckRequest();
                //request.TruckId = truckId;
                //var response = _truckService.GetTruckById(request);
               
                //Truck = response.Truck;
                //if (response.Truck != null)
                //    return Page();
            }
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
