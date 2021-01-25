using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HessTrucks.Web.Extensions
{
    public static class HttpClientExtensions
    {

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong executing Api: {response.ReasonPhrase}");
            var contentAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(contentAsString,new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
         }
    }
}

