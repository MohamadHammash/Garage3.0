using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3._0.Migrations
{
    public partial class FixedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boat",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Bus",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Car",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "Motorcycle",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehicleTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Boat",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bus",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Car",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motorcycle",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
