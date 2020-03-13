using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class ko3k1o31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRestaurants");

            migrationBuilder.DropColumn(
                name: "BestPromotions",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "postlike",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestPromotions",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "postlike",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRestaurants",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRestaurants", x => new { x.RestaurantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRestaurants_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRestaurants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRestaurants_UserId",
                table: "UserRestaurants",
                column: "UserId");
        }
    }
}
