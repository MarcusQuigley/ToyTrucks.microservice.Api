using Microsoft.EntityFrameworkCore.Migrations;

namespace HessTrucks.Services.TruckCatalog.Migrations
{
    public partial class AddIsMiniColumnToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMiniTruck",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMiniTruck",
                table: "Categories");
        }
    }
}
