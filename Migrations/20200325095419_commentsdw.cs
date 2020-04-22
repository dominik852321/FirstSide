using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class commentsdw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "a81f9d37-16cc-4d58-85e5-8d183a500744");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bb2579f-ee3b-4213-8280-d2b24a2838d3", "AQAAAAEAACcQAAAAEHX728b71d6NI/mKTo4VyMwBpyhGqXKuWKcd2SPLDGb4gAdP/MTjFF7k+fxZVRNb5A==", "0a8b2f3a-0f04-4b59-9834-9ae0a38030db" });
        }
    }
}
