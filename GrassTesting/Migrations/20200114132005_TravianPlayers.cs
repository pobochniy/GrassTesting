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
                    RankPopulation = table.Column<string>(nullable: true),
                    CountPopulation = table.Column<string>(nullable: true),
                    RankAtt = table.Column<string>(nullable: true),
                    PointAtt = table.Column<string>(nullable: true),
                    RankDef = table.Column<string>(nullable: true),
                    PointDef = table.Column<string>(nullable: true),
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
                    Id = table.Column<int>(nullable: false)
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
