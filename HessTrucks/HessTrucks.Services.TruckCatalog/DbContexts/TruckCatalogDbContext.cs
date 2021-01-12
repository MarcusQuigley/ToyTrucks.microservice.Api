 
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
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     //       base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Truck>()
            //    .HasMany(t => t.Photos)
            //    .WithOne(prop => prop.Truck)
            //    .IsRequired();

            //modelBuilder.Entity<TruckCategory>()
            //    .HasKey(tc => new { tc.TruckId, tc.CategoryId });

        }
    }
}
