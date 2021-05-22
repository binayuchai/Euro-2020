using Microsoft.EntityFrameworkCore.Migrations;

namespace euro_bet.Migrations
{
    public partial class UserAccountMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountID",
                table: "User",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Account_AccountID",
                table: "User",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Account_AccountID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AccountID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "User");
        }
    }
}
