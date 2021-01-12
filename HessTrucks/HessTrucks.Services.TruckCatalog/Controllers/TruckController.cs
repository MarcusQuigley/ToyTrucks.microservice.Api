using HessTrucks.Services.TruckCatalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<TruckController> _logger;

        public TruckController(ITruckRepository truckService, ILogger<TruckController> logger)
        {
            _truckService = truckService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public async Task<ActionResult> TrucksByCategoryId(int categoryId)
        {
            var trucks = await _truckService.GetTrucksByCategoryId(categoryId);
            return Ok(trucks);


        }

        [HttpGet]
        [Route("TruckControllerLoggingLevels")]
        public async Task<ActionResult> TruckControllerLoggingLevels()
        {
             
            _logger.LogTrace("TRACE!");
            _logger.LogDebug("DEBUG!");
            _logger.LogInformation("INFO!");
            _logger.LogWarning("WARN!");
            _logger.LogError("ERROR!");
            _logger.LogCritical("Critical!");
            return Ok();
          //  return Ok(await _truckService.GetTrucks( ));


        }
    }


}
