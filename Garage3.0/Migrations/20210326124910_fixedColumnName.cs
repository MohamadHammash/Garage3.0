using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3._0.Migrations
{
    public partial class fixedColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfwheeels",
                table: "Vehicles",
                newName: "NumberOfWheels");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "NumberOfWheels",
                table: "Vehicles",
                newName: "NumberOfwheeels");
        }
    }
}
