 
using HessTrucks.Services.TruckCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HessTrucks.Services.TruckCatalog.DbContexts
{
    public class TruckCatalogDbContext : DbContext
    {
        public TruckCatalogDbContext(DbContextOptions<TruckCatalogDbContext> options )
            : base(options)
        { 
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     //       base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Truck>()
                .HasMany(t => t.Photos)
                .WithOne(prop => prop.Truck)
                .IsRequired();
        }
    }
}
