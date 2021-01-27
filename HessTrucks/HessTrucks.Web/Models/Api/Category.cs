using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HessTrucks.Web.Models.Api
{
    [XmlRoot("CategoryDto"), XmlType("CategoryDto")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsMiniTruck { get; set; }
        public int Order { get; set; }
    }
}
