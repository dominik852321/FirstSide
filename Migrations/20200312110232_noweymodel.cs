using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstSide.Migrations
{
    public partial class noweymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRestaurant");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Photos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Club_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ClubId",
                table: "Photos",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClubId",
                table: "Events",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_RestaurantId",
                table: "Events",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_UserId",
                table: "Club",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Club_ClubId",
                table: "Events",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Restaurants_RestaurantId",
                table: "Events",
                column: "RestaurantId",
                principalTable: "Restaurants",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Club_ClubId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Restaurants_RestaurantId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Club_ClubId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropIndex(
                name: "IX_Photos_ClubId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Events_ClubId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_RestaurantId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "EventRestaurant",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRestaurant", x => new { x.EventId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_EventRestaurant_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRestaurant_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRestaurant_RestaurantId",
                table: "EventRestaurant",
                column: "RestaurantId");
        }
    }
}
