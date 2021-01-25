using AutoMapper;
using HessTrucks.Services.TruckCatalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Controllers
{
    [Route("api/trucks")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckRepository _truckService;
        private readonly ILogger<TruckController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public TruckController(ITruckRepository truckService, ILogger<TruckController> logger, IMapper mapper, IConfiguration config)
        {
            _truckService = truckService;
            _logger = logger;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet]
        [Route("{categoryId:int}")]
        public async Task<ActionResult<IEnumerable<Models.TruckDto>>> TrucksByCategoryId(int categoryId)
        {
            var trucks = await _truckService.GetTrucksByCategoryId(categoryId);
            var trucksDtos = _mapper.Map<IEnumerable<Models.TruckDto>>(trucks);
            return Ok(trucksDtos);


        }

        [HttpGet]
        [Route("TruckControllerLoggingLevels")]
        public async Task<ActionResult> TruckControllerLoggingLevels()
        {
            _logger.LogInformation("In TruckControllerLoggingLevels!");
            _logger.LogTrace("TRACE!");
            _logger.LogDebug("DEBUG!");
            _logger.LogInformation("INFO!");
            _logger.LogWarning("WARN!");
            _logger.LogError("ERROR!");
            _logger.LogCritical("Critical!");
            return Ok();
        }
    }


}
