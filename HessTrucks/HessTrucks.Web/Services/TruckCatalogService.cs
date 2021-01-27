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
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 0.7));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.8));


        }

        public Task<Truck> AddTruck(Truck truck)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            IList<Category> categories = null;
            try
            {

                var response = await _client.GetAsync("api/categories");
                response.EnsureSuccessStatusCode();

               var content = await response.Content.ReadAsStringAsync();


                _logger.LogInformation(response.Content.Headers.ContentType.MediaType);
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    categories = JsonSerializer.Deserialize<List<Category>>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else if (response.Content.Headers.ContentType.MediaType == "application/xml")
                {
                    var serializer = new XmlSerializer(typeof(List<Category>) );
                    categories = (List<Models.Api.Category>)serializer.Deserialize(new StringReader(content));
                }
                _logger.LogInformation("categories count: {0}", categories?.Count());
               _logger.LogInformation("categories 1: {0}", categories?[0]?.Name);
            }
            catch (Exception ex)
            {

                _logger.LogError("Error {0}", ex.InnerException?.ToString());
            }
            return categories;
        }

        public async Task<IEnumerable<Category>> GetCategoriesBySize(bool isMini)
        {
            var response =await _client.GetAsync($"api/categories/{isMini}");
            return await response.ReadContentAs<IEnumerable<Category>>();
         }

        public async Task<Truck> GetTruck(Guid truckId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Truck>> GetTrucks(Guid truckId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Truck>> GetTrucksByCategoryId(int categoryId)
        {
            var response = await _client.GetAsync($"api/trucks/{categoryId}");
            return await response.ReadContentAs<List<Truck>>();
        }

        public Task<Truck> UpdateTruck(Truck truck)
        {
            throw new NotImplementedException();
        }
    }
    
}
