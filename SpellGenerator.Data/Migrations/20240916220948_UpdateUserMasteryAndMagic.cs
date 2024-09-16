using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpellGenerator.Data.Migrations
{
    public partial class UpdateUserMasteryAndMagic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magics_User_UserId",
                table: "Magics");

            migrationBuilder.DropForeignKey(
                name: "FK_Masteries_User_UserId",
                table: "Masteries");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellMasteries_Magics_MagicId",
                table: "SpellMasteries");

            migrationBuilder.DropForeignKey(
                name: "FK_SpellMasteries_Masteries_MasteryId",
                table: "SpellMasteries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellMasteries",
                table: "SpellMasteries");

            migrationBuilder.DropIndex(
                name: "IX_SpellMasteries_MasteryId",
                table: "SpellMasteries");

            migrationBuilder.DropIndex(
                name: "IX_Masteries_UserId",
                table: "Masteries");

            migrationBuilder.DropIndex(
                name: "IX_Magics_UserId",
                table: "Magics");

            migrationBuilder.DropColumn(
                name: "MagicId",
                table: "SpellMasteries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Masteries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Magics");

            migrationBuilder.AlterColumn<int>(
                name: "MasteryId",
                table: "SpellMasteries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellMasteries",
                table: "SpellMasteries",
                columns: new[] { "MasteryId", "SpellId" });

            migrationBuilder.CreateTable(
                name: "SpellMagics",
                columns: table => new
                {
                    MagicId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellMagics", x => new { x.MagicId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_SpellMagics_Magics_MagicId",
                        column: x => x.MagicId,
                        principalTable: "Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellMagics_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMagics",
                columns: table => new
                {
                    MagicId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMagics", x => new { x.MagicId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMagics_Magics_MagicId",
                        column: x => x.MagicId,
                        principalTable: "Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMagics_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMasteries",
                columns: table => new
                {
                    MasteryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasteries", x => new { x.MasteryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMasteries_Masteries_MasteryId",
                        column: x => x.MasteryId,
                        principalTable: "Masteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMasteries_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellMagics_SpellId",
                table: "SpellMagics",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMagics_UserId",
                table: "UserMagics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasteries_UserId",
                table: "UserMasteries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpellMasteries_Masteries_MasteryId",
                table: "SpellMasteries",
                column: "MasteryId",
                principalTable: "Masteries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpellMasteries_Masteries_MasteryId",
                table: "SpellMasteries");

            migrationBuilder.DropTable(
                name: "SpellMagics");

            migrationBuilder.DropTable(
                name: "UserMagics");

            migrationBuilder.DropTable(
                name: "UserMasteries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpellMasteries",
                table: "SpellMasteries");

            migrationBuilder.AlterColumn<int>(
                name: "MasteryId",
                table: "SpellMasteries",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "MagicId",
                table: "SpellMasteries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Masteries",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Magics",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpellMasteries",
                table: "SpellMasteries",
                columns: new[] { "MagicId", "SpellId" });

            migrationBuilder.CreateIndex(
                name: "IX_SpellMasteries_MasteryId",
                table: "SpellMasteries",
                column: "MasteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Masteries_UserId",
                table: "Masteries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Magics_UserId",
                table: "Magics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Magics_User_UserId",
                table: "Magics",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Masteries_User_UserId",
                table: "Masteries",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpellMasteries_Magics_MagicId",
                table: "SpellMasteries",
                column: "MagicId",
                principalTable: "Magics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpellMasteries_Masteries_MasteryId",
                table: "SpellMasteries",
                column: "MasteryId",
                principalTable: "Masteries",
                principalColumn: "Id");
        }
    }
}
