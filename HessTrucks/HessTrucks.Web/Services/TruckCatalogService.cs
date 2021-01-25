using HessTrucks.Web.Extensions;
using HessTrucks.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HessTrucks.Web.Services
{
    public class TruckCatalogService : ITruckCatalogService
    {
        private readonly HttpClient client;

        public TruckCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public Task<Truck> AddTruck(Truck truck)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
             
        }

        public async Task<IEnumerable<Category>> GetCategoriesBySize(bool isMini)
        {
            var response =await client.GetAsync($"api/categories/{isMini}");
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
            var response = await client.GetAsync($"api/trucks/{categoryId}");
            return await response.ReadContentAs<List<Truck>>();
        }

        public Task<Truck> UpdateTruck(Truck truck)
        {
            throw new NotImplementedException();
        }
    }
    
}
