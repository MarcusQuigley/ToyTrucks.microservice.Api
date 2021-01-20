using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HessTrucks.Grpc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HessTrucks.Web.Pages.Toys
{
    public class IndexModel : PageModel
    {
        private readonly Trucks.TrucksClient _truckService;
       
        public IEnumerable<Truck> Trucks { get; set; }
        public IndexModel(Trucks.TrucksClient truckService)
        {
            _truckService = truckService;
        }
        public async  Task<IActionResult> OnGet()
        {
            var response =await _truckService.GetAllTrucksAsync(new GetAllTrucksRequest());
            //var response =   _truckService.GetAllTrucks(new GetAllTrucksRequest());
            Trucks = response.Trucks;
            return Page();
        }
    }
}
