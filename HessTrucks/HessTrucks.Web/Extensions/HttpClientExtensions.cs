using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HessTrucks.Web.Extensions
{
    public static class HttpClientExtensions
    { 
        public static async Task<T> DeserializeJson<T>(this HttpResponseMessage response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
            response.EnsureSuccessStatusCode();
            //if (response.Content.Headers.ContentType.MediaType != "application/json") { }
            var contentAsString = await response.Content.ReadAsStringAsync();
            return (T)JsonSerializer.Deserialize<T>(contentAsString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<T> DeserializeXml<T>(this HttpResponseMessage response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));
            response.EnsureSuccessStatusCode();
            var contentAsString = await response.Content.ReadAsStringAsync();
            var xmlDeserializer = new XmlSerializer(typeof(T));
            return (T)xmlDeserializer.Deserialize(new StringReader(contentAsString));
        }

    }
}

