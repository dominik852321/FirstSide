using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class newewq1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostCode",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clubs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Clubs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostCode",
                table: "Clubs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Clubs");
        }
    }
}
