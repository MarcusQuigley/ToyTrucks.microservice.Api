using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HessTrucks.Web.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessTrucks.Web.Pages.Toys
{
    public class DetailModel : PageModel
    {

        public Truck Truck { get; set; }
        public DetailModel ()
        {
    
        }

     
        //public async  Task<IActionResult> OnGetAsync(string truckId)
        //{
        //    if (truckId != null)
        //    {
        //        var request = new GetTruckRequest();
        //        request.TruckId = truckId;
        //           var response = await _truckService.GetTruckByIdAsync(request);
                
        //        Truck = response.Truck;
        //        if (response.Truck != null)
        //            return Page();
        //    }
        //    return RedirectToPage("./NotFound");
            
        //}

        public    IActionResult OnGet(string truckId)
        {
            if (truckId != null)
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
    }
}
