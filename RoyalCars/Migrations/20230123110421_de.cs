using Microsoft.EntityFrameworkCore.Migrations;

namespace RoyalCars.Migrations
{
    public partial class de : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Reserves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reserves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reserves",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ContactUs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ContactUs");
        }
    }
}
