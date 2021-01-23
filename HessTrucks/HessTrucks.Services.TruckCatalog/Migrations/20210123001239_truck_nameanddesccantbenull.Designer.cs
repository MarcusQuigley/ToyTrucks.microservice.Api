﻿// <auto-generated />
using System;
using HessTrucks.Services.TruckCatalog.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HessTrucks.Services.TruckCatalog.Migrations
{
    [DbContext(typeof(TruckCatalogDbContext))]
    [Migration("20210123001239_truck_nameanddesccantbenull")]
    partial class truck_nameanddesccantbenull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CategoryTruck", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("TrucksTruckId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesCategoryId", "TrucksTruckId");

                    b.HasIndex("TrucksTruckId");

                    b.ToTable("CategoryTruck");
                });

            modelBuilder.Entity("HessTrucks.Services.TruckCatalog.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsMiniTruck")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HessTrucks.Services.TruckCatalog.Entities.Photo", b =>
                {
                    b.Property<Guid>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TruckId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PhotoId");

                    b.HasIndex("TruckId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("HessTrucks.Services.TruckCatalog.Entities.Truck", b =>
                {
                    b.Property<Guid>("TruckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NewID()");

                    b.Property<bool>("Damaged")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("DefaultPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hidden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PreviousPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("TruckId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("CategoryTruck", b =>
                {
                    b.HasOne("HessTrucks.Services.TruckCatalog.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HessTrucks.Services.TruckCatalog.Entities.Truck", null)
                        .WithMany()
                        .HasForeignKey("TrucksTruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HessTrucks.Services.TruckCatalog.Entities.Photo", b =>
                {
                    b.HasOne("HessTrucks.Services.TruckCatalog.Entities.Truck", "Truck")
                        .WithMany("Photos")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Truck");
                });

            modelBuilder.Entity("HessTrucks.Services.TruckCatalog.Entities.Truck", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
