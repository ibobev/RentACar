using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSCB766_RentACar.Migrations
{
    public partial class AddDateAndTotalCostToRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "RentedVehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "RentedVehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "TotalCost",
                table: "RentedVehicles",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "RentedVehicles");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "RentedVehicles");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "RentedVehicles");
        }
    }
}
