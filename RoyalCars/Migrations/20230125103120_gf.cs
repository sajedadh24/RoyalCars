using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalCars.Migrations
{
    public partial class gf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Companies");
        }
    }
}
