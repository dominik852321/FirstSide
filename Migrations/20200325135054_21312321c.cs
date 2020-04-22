using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _21312321c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Clubs_ClubId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurants_RestaurantId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "f6ebc80d-ea2d-4d42-9d09-2654bf6736fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "245b5b65-2fba-4025-b374-bb47742e27f6", "AQAAAAEAACcQAAAAEKUV67+VeG+uH0+Pg4SpkfIsHuNlE4oWkVlXtovRSHXR544TBsVET/Oucmca7P77pg==", "0304a89f-ef36-41fe-8ec7-ef7aad12b6cf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Clubs_ClubId",
                table: "Comments",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Restaurants_RestaurantId",
                table: "Comments",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Clubs_ClubId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurants_RestaurantId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClubId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "fdaffdf1-db7b-470d-a904-986c4bfda33f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9c11513-fedf-41a9-808b-e6aee527b810", "AQAAAAEAACcQAAAAEHtyyv30w1P1vzfy9NDOPJwz+EWjCgs74CA550Jtp6a9+4SB7rECm3LIkars5syRkQ==", "52258d8c-9595-4867-85fe-86c128e631cb" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Clubs_ClubId",
                table: "Comments",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Restaurants_RestaurantId",
                table: "Comments",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
