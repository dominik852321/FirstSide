using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _21321321v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "b094f138-3b9a-4640-aee3-d35951378bbd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7ae9715-8e95-44f5-8275-56cd569db303", "AQAAAAEAACcQAAAAEJddhiviEOoKJhcfwTyZynMv61+ct75rUJKdxiB3kbDmAeAma+p/Bhfvk/JDIqsKog==", "1d2277e6-417b-43d1-b94b-e648055c3405" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ClubId",
                table: "Comments",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments",
                column: "RestaurantId",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Clubs_ClubId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Restaurants_RestaurantId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ClubId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "32fb4030-6498-4355-82f4-17166222218e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53cd5434-0c29-44b3-90c4-84a03561c2c9", "AQAAAAEAACcQAAAAECkkKnyTFg2y09lQdWz2qEFKfnHmhMEK7AlGQAaPp0QJv51DRQN5D2NppZG6t07bkQ==", "97728ff6-4b10-4e9c-820a-a547a793836f" });
        }
    }
}
