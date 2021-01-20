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
    }
}
