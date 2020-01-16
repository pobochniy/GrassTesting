using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrassTesting.Migrations
{
    public partial class TravianPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravianPlayersHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    Nation = table.Column<string>(nullable: true),
                    Clan = table.Column<string>(nullable: true),
                    CountVillages = table.Column<int>(nullable: false),
                    RankPopulation = table.Column<int>(nullable: false),
                    CountPopulation = table.Column<int>(nullable: false),
                    RankAtt = table.Column<int>(nullable: false),
                    PointAtt = table.Column<int>(nullable: false),
                    RankDef = table.Column<int>(nullable: false),
                    PointDef = table.Column<int>(nullable: false),
                    VillagesJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravianPlayersHistory", x => new { x.Id, x.Date });
                });

            migrationBuilder.CreateTable(
                name: "TravianPlayersId",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravianPlayersId", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravianPlayersHistory");

            migrationBuilder.DropTable(
                name: "TravianPlayersId");
        }
    }
}
