using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _12321c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Clubs_ClubId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Restaurants_Restaurantid",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Restaurantid",
                table: "Photos",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_Restaurantid",
                table: "Photos",
                newName: "IX_Photos_RestaurantId");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Clubs_ClubId",
                table: "Photos",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Restaurants_RestaurantId",
                table: "Photos",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Clubs_ClubId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Restaurants_RestaurantId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Photos",
                newName: "Restaurantid");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_RestaurantId",
                table: "Photos",
                newName: "IX_Photos_Restaurantid");

            migrationBuilder.AlterColumn<int>(
                name: "Restaurantid",
                table: "Photos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Photos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Clubs_ClubId",
                table: "Photos",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Restaurants_Restaurantid",
                table: "Photos",
                column: "Restaurantid",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
