﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
      //  public bool IsMiniTruck { get; set; }
        public int Order { get; set; }
        public virtual ICollection<TruckCategory> TruckCategories { get; set; }
    }
}
