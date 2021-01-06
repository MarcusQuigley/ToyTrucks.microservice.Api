﻿using System;

namespace HessTrucks.Services.TruckCatalog.Entities
{
    public class Photo
    {
        public Guid PhotoId { get; set; }
        public string PhotoPath { get; set; }

        public Guid TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}