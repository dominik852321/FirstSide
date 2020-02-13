using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class wqeqewqv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Menus_MenusId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_MenusId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenusId",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "Alcohol",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Drink",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Foods",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pizza",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "MenusId",
                table: "Restaurants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlcoholPromotions = table.Column<int>(type: "int", nullable: false),
                    DrinkPromotions = table.Column<int>(type: "int", nullable: false),
                    FoodsPromotions = table.Column<int>(type: "int", nullable: false),
                    PizzaPromotions = table.Column<int>(type: "int", nullable: false),
                    TablePromotions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_MenusId",
                table: "Restaurants",
                column: "MenusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Menus_MenusId",
                table: "Restaurants",
                column: "MenusId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
