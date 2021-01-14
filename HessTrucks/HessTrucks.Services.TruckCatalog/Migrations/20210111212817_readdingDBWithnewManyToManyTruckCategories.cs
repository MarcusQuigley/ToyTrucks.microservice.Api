using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HessTrucks.Services.TruckCatalog.Migrations
{
    public partial class readdingDBWithnewManyToManyTruckCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckCategory");

            migrationBuilder.CreateTable(
                name: "CategoryTruck",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    TrucksTruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTruck", x => new { x.CategoriesCategoryId, x.TrucksTruckId });
                    table.ForeignKey(
                        name: "FK_CategoryTruck_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTruck_Trucks_TrucksTruckId",
                        column: x => x.TrucksTruckId,
                        principalTable: "Trucks",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTruck_TrucksTruckId",
                table: "CategoryTruck",
                column: "TrucksTruckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTruck");

            migrationBuilder.CreateTable(
                name: "TruckCategory",
                columns: table => new
                {
                    TruckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckCategory", x => new { x.TruckId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TruckCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckCategory_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckCategory_CategoryId",
                table: "TruckCategory",
                column: "CategoryId");
        }
    }
}
