using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpellGenerator.Data.Migrations
{
    public partial class UpdatedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddOns_Spells_SpellId",
                table: "AddOns");

            migrationBuilder.DropForeignKey(
                name: "FK_Magics_Spells_SpellId",
                table: "Magics");

            migrationBuilder.DropForeignKey(
                name: "FK_Masteries_Spells_SpellId",
                table: "Masteries");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_SpellBooks_SpellBookId",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_Spells_SpellBookId",
                table: "Spells");

            migrationBuilder.DropIndex(
                name: "IX_AddOns_SpellId",
                table: "AddOns");

            migrationBuilder.DropColumn(
                name: "SpellBookId",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "SpellId",
                table: "AddOns");

            migrationBuilder.RenameColumn(
                name: "SpellId",
                table: "Masteries",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Masteries_SpellId",
                table: "Masteries",
                newName: "IX_Masteries_UserId");

            migrationBuilder.RenameColumn(
                name: "SpellId",
                table: "Magics",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Magics_SpellId",
                table: "Magics",
                newName: "IX_Magics_UserId");

            migrationBuilder.CreateTable(
                name: "SpellAddOn",
                columns: table => new
                {
                    AddOnId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellAddOn", x => new { x.AddOnId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_SpellAddOn_AddOns_AddOnId",
                        column: x => x.AddOnId,
                        principalTable: "AddOns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellAddOn_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellBookSpell",
                columns: table => new
                {
                    SpellBookId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellBookSpell", x => new { x.SpellBookId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_SpellBookSpell_SpellBooks_SpellBookId",
                        column: x => x.SpellBookId,
                        principalTable: "SpellBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellBookSpell_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpellMasteries",
                columns: table => new
                {
                    MagicId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false),
                    MasteryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellMasteries", x => new { x.MagicId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_SpellMasteries_Magics_MagicId",
                        column: x => x.MagicId,
                        principalTable: "Magics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellMasteries_Masteries_MasteryId",
                        column: x => x.MasteryId,
                        principalTable: "Masteries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpellMasteries_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellBookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_SpellBooks_SpellBookId",
                        column: x => x.SpellBookId,
                        principalTable: "SpellBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellAddOn_SpellId",
                table: "SpellAddOn",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellBookSpell_SpellId",
                table: "SpellBookSpell",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellMasteries_MasteryId",
                table: "SpellMasteries",
                column: "MasteryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellMasteries_SpellId",
                table: "SpellMasteries",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SpellBookId",
                table: "User",
                column: "SpellBookId",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magics_User_UserId",
                table: "Magics");

            migrationBuilder.DropForeignKey(
                name: "FK_Masteries_User_UserId",
                table: "Masteries");

            migrationBuilder.DropTable(
                name: "SpellAddOn");

            migrationBuilder.DropTable(
                name: "SpellBookSpell");

            migrationBuilder.DropTable(
                name: "SpellMasteries");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Masteries",
                newName: "SpellId");

            migrationBuilder.RenameIndex(
                name: "IX_Masteries_UserId",
                table: "Masteries",
                newName: "IX_Masteries_SpellId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Magics",
                newName: "SpellId");

            migrationBuilder.RenameIndex(
                name: "IX_Magics_UserId",
                table: "Magics",
                newName: "IX_Magics_SpellId");

            migrationBuilder.AddColumn<int>(
                name: "SpellBookId",
                table: "Spells",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpellId",
                table: "AddOns",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SpellBookId",
                table: "Spells",
                column: "SpellBookId");

            migrationBuilder.CreateIndex(
                name: "IX_AddOns_SpellId",
                table: "AddOns",
                column: "SpellId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddOns_Spells_SpellId",
                table: "AddOns",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Magics_Spells_SpellId",
                table: "Magics",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Masteries_Spells_SpellId",
                table: "Masteries",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_SpellBooks_SpellBookId",
                table: "Spells",
                column: "SpellBookId",
                principalTable: "SpellBooks",
                principalColumn: "Id");
        }
    }
}
