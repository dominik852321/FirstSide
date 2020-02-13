using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class wqewqeqwv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alcohol",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Drink",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Foods",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Pizza",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pizza = table.Column<int>(nullable: false),
                    Alcohol = table.Column<int>(nullable: false),
                    Drink = table.Column<int>(nullable: false),
                    Foods = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MenuId",
                table: "Restaurants",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menu_MenuId",
                table: "Restaurants",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menu_MenuId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_MenuId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "Alcohol",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Drink",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Foods",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pizza",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
