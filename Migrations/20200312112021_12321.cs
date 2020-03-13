using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class _12321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_UserId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Club_ClubId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Club_ClubId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.RenameTable(
                name: "Club",
                newName: "Clubs");

            migrationBuilder.RenameIndex(
                name: "IX_Club_UserId",
                table: "Clubs",
                newName: "IX_Clubs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AspNetUsers_UserId",
                table: "Clubs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Clubs_ClubId",
                table: "Events",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Clubs_ClubId",
                table: "Photos",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AspNetUsers_UserId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Clubs_ClubId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Clubs_ClubId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "Club");

            migrationBuilder.RenameIndex(
                name: "IX_Clubs_UserId",
                table: "Club",
                newName: "IX_Club_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_UserId",
                table: "Club",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Club_ClubId",
                table: "Events",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Club_ClubId",
                table: "Photos",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
