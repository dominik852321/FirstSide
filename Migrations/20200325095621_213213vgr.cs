using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _213213vgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TimeInsert = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<int>(nullable: false),
                    ClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "5f91b248-aacc-4461-a7d1-f3827190bc93");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fedd618e-d57a-422c-9fda-acfeab35f5e8", "AQAAAAEAACcQAAAAEM1BRGpPzvvEPe3OX1ntf3UMIr488XmKjUFAELhmk+leuhoLTaDgZ1pL5TBUlMLdVQ==", "49b572f0-c9d2-4cc0-ac74-a6775b472e74" });
        }
    }
}
