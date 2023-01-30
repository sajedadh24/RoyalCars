using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalCars.Migrations
{
    public partial class HH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideURL",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideURL",
                table: "Companies");
        }
    }
}
