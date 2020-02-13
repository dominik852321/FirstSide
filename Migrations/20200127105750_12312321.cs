using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _12312321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
