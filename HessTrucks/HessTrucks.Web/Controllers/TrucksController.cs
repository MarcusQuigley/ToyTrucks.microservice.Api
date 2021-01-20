using HessTrucks.Grpc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace HessTrucks.Web.Controllers
{
    public class TrucksController : Controller
    {
        private readonly Trucks.TrucksClient _truckService;

        public TrucksController(Trucks.TrucksClient truckService)
        {
            _truckService = truckService;
        }

        public async Task<IActionResult>  Index()
        {
            var trucks = await _truckService.GetAllTrucksAsync(new GetAllTrucksRequest());
        
            return View(trucks);
        }
    }
}
