using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage3._0.Migrations
{
    public partial class PluralName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotVehicle_ParkingSpot_ParkingSpotsId",
                table: "ParkingSpotVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotVehicle_Vehicle_VehiclesId",
                table: "ParkingSpotVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Member_MemberId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleType",
                table: "VehicleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSpot",
                table: "ParkingSpot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "VehicleType",
                newName: "VehicleTypes");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "ParkingSpot",
                newName: "ParkingSpots");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_MemberId",
                table: "Vehicles",
                newName: "IX_Vehicles_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSpots",
                table: "ParkingSpots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotVehicle_ParkingSpots_ParkingSpotsId",
                table: "ParkingSpotVehicle",
                column: "ParkingSpotsId",
                principalTable: "ParkingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotVehicle_Vehicles_VehiclesId",
                table: "ParkingSpotVehicle",
                column: "VehiclesId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Members_MemberId",
                table: "Vehicles",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotVehicle_ParkingSpots_ParkingSpotsId",
                table: "ParkingSpotVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpotVehicle_Vehicles_VehiclesId",
                table: "ParkingSpotVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Members_MemberId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingSpots",
                table: "ParkingSpots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "VehicleTypes",
                newName: "VehicleType");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "ParkingSpots",
                newName: "ParkingSpot");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_MemberId",
                table: "Vehicle",
                newName: "IX_Vehicle_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleType",
                table: "VehicleType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingSpot",
                table: "ParkingSpot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotVehicle_ParkingSpot_ParkingSpotsId",
                table: "ParkingSpotVehicle",
                column: "ParkingSpotsId",
                principalTable: "ParkingSpot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpotVehicle_Vehicle_VehiclesId",
                table: "ParkingSpotVehicle",
                column: "VehiclesId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Member_MemberId",
                table: "Vehicle",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
