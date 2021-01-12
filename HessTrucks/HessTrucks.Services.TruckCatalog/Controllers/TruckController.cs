using HessTrucks.Services.TruckCatalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Controllers
{
    [Route("api/Truck")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckRepository _truckService;

        public TruckController(ITruckRepository truckService)
        {
            _truckService = truckService;
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public async Task<ActionResult> TrucksByCategoryId(int categoryId)
        {
            var trucks = await _truckService.GetTrucksByCategoryId(categoryId);
            return Ok(trucks);


        }

        [HttpGet]
        public async Task<ActionResult> Trucks()
        {
            return Ok(await _truckService.GetTrucks( ));


        }
    }


}
