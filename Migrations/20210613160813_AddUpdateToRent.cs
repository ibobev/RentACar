using Microsoft.EntityFrameworkCore.Migrations;

namespace CSCB766_RentACar.Migrations
{
    public partial class AddUpdateToRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "RentedVehicles",
                newName: "Cost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "RentedVehicles",
                newName: "TotalCost");
        }
    }
}
