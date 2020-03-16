using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _12321vq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventRestaurants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventClubs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clubs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventRestaurants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventClubs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clubs");
        }
    }
}
