using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class huge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Promotions",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "BestPromotions",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Close",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Open",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestPromotions",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "Promotions",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
