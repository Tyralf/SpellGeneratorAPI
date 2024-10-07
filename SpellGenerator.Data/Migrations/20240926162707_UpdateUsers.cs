using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpellGenerator.Data.Migrations
{
    public partial class UpdateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_SpellBooks_SpellBookId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMagics_User_UserId",
                table: "UserMagics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMasteries_User_UserId",
                table: "UserMasteries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_SpellBookId",
                table: "Users",
                newName: "IX_Users_SpellBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMagics_Users_UserId",
                table: "UserMagics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMasteries_Users_UserId",
                table: "UserMasteries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SpellBooks_SpellBookId",
                table: "Users",
                column: "SpellBookId",
                principalTable: "SpellBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMagics_Users_UserId",
                table: "UserMagics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMasteries_Users_UserId",
                table: "UserMasteries");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SpellBooks_SpellBookId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_SpellBookId",
                table: "User",
                newName: "IX_User_SpellBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_SpellBooks_SpellBookId",
                table: "User",
                column: "SpellBookId",
                principalTable: "SpellBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMagics_User_UserId",
                table: "UserMagics",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMasteries_User_UserId",
                table: "UserMasteries",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
