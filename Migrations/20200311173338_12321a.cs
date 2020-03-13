using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _12321a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Events");
        }
    }
}
