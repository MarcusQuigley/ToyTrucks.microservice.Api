using AutoMapper;
using HessTrucks.Services.TruckCatalog.Models;
using HessTrucks.Services.TruckCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController :ControllerBase
    {
        private readonly ICategoryRepository _service;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository service, ILogger<CategoryController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{isMini:bool}")]
         public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(bool isMini)
        {
            var categories = await _service.GetCategoriesBySize(isMini);
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

    }
}
