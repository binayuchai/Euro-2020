using Microsoft.EntityFrameworkCore.Migrations;

namespace euro_bet.Migrations
{
    public partial class PersonClassUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
