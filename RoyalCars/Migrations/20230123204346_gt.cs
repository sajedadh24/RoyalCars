using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalCars.Migrations
{
    public partial class gt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reserves_CarId",
                table: "Reserves",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Cars_CarId",
                table: "Reserves",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Cars_CarId",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_CarId",
                table: "Reserves");
        }
    }
}
