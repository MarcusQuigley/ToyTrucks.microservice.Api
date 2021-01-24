using AutoMapper;
using Grpc.Core;
using HessTrucks.Grpc;
using HessTrucks.Services.TruckCatalog.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Services
{
    public class TruckGrpcService : Trucks.TrucksBase
    {
        private readonly ITruckRepository _truckService;
        private readonly ICategoryRepository _categoryService;
        private readonly ILogger<TruckGrpcService> _logger;
        private readonly IMapper _mapper;
        public TruckGrpcService(ITruckRepository truckService,
                                ILogger<TruckGrpcService> logger, 
                                IMapper mapper)
        {
            _truckService = truckService;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task<GetAllTrucksResponse> GetAllTrucks(GetAllTrucksRequest request, ServerCallContext context)
        {
            var response = new GetAllTrucksResponse();
            
            var trucks = await _truckService.GetTrucks();
            _logger.LogWarning("Got {0} trucks",trucks.Count());
             
            response.Trucks.Add(_mapper.Map<List<Truck>>(trucks));

            return response;
        }

        public override async Task<GetCategoriesResponse> GetAllCategoriesBySize(GetAllCategoriesBySizeRequest request, ServerCallContext context)
        {
            var response = new GetCategoriesResponse();

            var categories = await _categoryService.GetGategoriesBySize(request.IsMini);
            _logger.LogWarning("Got {0} categories", categories.Count());

            response.Categories.Add(_mapper.Map<List<Category>>(categories));

            return response;
        }

        public override async Task<GetTruckByTruckIdResponse> GetTruckById(GetTruckRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.TruckId, out Guid truckId))
                throw new ArgumentException($"{nameof(request.TruckId)} is not a valid Guid");
            var response = new GetTruckByTruckIdResponse();
            var truck = await _truckService.GetTruckById(truckId);
            response.Truck = _mapper.Map<Truck>(truck);
            return response;
        }
        public async override Task<AddTruckResponse> AddTruck(AddTruckRequest request, ServerCallContext context)
        {
            var response = new AddTruckResponse()
            {
                Success = Protos.ReadingStatus.Failure
            };

            try
            {
                var truck = _mapper.Map<HessTrucks.Services.TruckCatalog.Entities.Truck>(request.Truck);
                await _truckService.AddTruck(truck);
                if (await _truckService.SaveChanges() == true)
                    response.Success = Protos.ReadingStatus.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception thrown during Add truck: {ex}", ex);
                response.Message = "Exception thrown during Add truck";
            }
            
            return response;
        }

        public override async Task<UpdateTruckResponse> UpdateTruck(UpdateTruckRequest request, ServerCallContext context)
        {
            var response = new UpdateTruckResponse() 
            { 
                Success = Protos.ReadingStatus.Failure 
            };
            try
            {
                var truck = _mapper.Map<HessTrucks.Services.TruckCatalog.Entities.Truck>(request.Truck);
                _truckService.UpdateTruck(truck);
                if (await _truckService.SaveChanges() == true)
                {
                    response.Success = Protos.ReadingStatus.Success;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception thrown during update truck: {ex}", ex);
                response.Message = "Exception thrown during update truck";
            }
            return response;

        }

    }
}
