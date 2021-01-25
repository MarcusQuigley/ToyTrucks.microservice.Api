using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Web.Models.Api
{
    public class Photo
    {
        public Guid PhotoId { get; set; }
        public string PhotoPath { get; set; }
        public Guid TruckId { get; set; }
    }
}
