using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace euro_bet.Migrations
{
    public partial class FixtureAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fixture",
                columns: table => new
                {
                    FixtureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SquadHomeSquadID = table.Column<int>(type: "int", nullable: true),
                    SquadAwaySquadID = table.Column<int>(type: "int", nullable: true),
                    Score_HalfTime_Home = table.Column<int>(type: "int", nullable: false),
                    Score_HalfTime_Away = table.Column<int>(type: "int", nullable: false),
                    Score_FullTime_Home = table.Column<int>(type: "int", nullable: false),
                    Score_FullTime_Away = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixture", x => x.FixtureID);
                    table.ForeignKey(
                        name: "FK_Fixture_Squad_SquadAwaySquadID",
                        column: x => x.SquadAwaySquadID,
                        principalTable: "Squad",
                        principalColumn: "SquadID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixture_Squad_SquadHomeSquadID",
                        column: x => x.SquadHomeSquadID,
                        principalTable: "Squad",
                        principalColumn: "SquadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixture_SquadAwaySquadID",
                table: "Fixture",
                column: "SquadAwaySquadID");

            migrationBuilder.CreateIndex(
                name: "IX_Fixture_SquadHomeSquadID",
                table: "Fixture",
                column: "SquadHomeSquadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixture");
        }
    }
}
