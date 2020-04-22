using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class dsaqweqw11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments");

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments");

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
                name: "IX_Comments_RestaurantId",
                table: "Comments",
                column: "RestaurantId",
                unique: true);
        }
    }
}
