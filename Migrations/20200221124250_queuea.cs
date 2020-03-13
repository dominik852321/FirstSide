using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class queuea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
