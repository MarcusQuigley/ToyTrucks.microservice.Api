using HessTrucks.Web.Extensions;
using HessTrucks.Web.Models.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HessTrucks.Web.Services
{
    public class TruckCatalogService : ITruckCatalogService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<TruckCatalogService> _logger;
        public TruckCatalogService(HttpClient client, IConfiguration configuration, ILogger<TruckCatalogService> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _client = client;
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.BaseAddress = new Uri(_configuration["ApiConfigs:TruckCatalog:Uri"]);
        }

        public Task<Truck> AddTruck(Truck truck)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await GetDataAsJson<IEnumerable<Category>>($"api/categories");
             return categories;
         }

        public async Task<IEnumerable<Category>> GetCategoriesBySize(bool isMini)
        {
            var categories =await GetDataAsJson<IEnumerable<Category>>($"api/categories/{isMini}");
            return categories;
        }

        public async Task<Truck> GetTruck(Guid truckId)
        {
            return await GetDataAsJson<Truck>($"api/trucks/{truckId}");
        }

        public async Task<IEnumerable<Truck>> GetTrucks(Guid truckId)
        {
            return await GetDataAsJson<IEnumerable<Truck>>("api/trucks");
        }

        public async Task<IEnumerable<Truck>> GetTrucksByCategoryId(int categoryId)
        {
            var trucks = await GetDataAsJson<IEnumerable<Truck>>($"api/trucks/{categoryId}");
            return trucks;
        }

        public Task<Truck> UpdateTruck(Truck truck)
        {
            throw new NotImplementedException();
        }

        async Task<T> GetDataAsJson<T>(string requestUri)
        {
            T data = default;
            _client.DefaultRequestHeaders.Accept.Clear();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await _client.SendAsync(request);
                data = await response.DeserializeJson<T>();
            }
            catch (Exception e)
            {
                _logger.LogError("Error {0}", e.InnerException?.ToString());
            }
            return data;
        }
    }
    

}
