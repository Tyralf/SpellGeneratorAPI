using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpellGenerator.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddOns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    InstabilityValue = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifierValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Magics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Masteries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentMasteryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masteries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Masteries_Masteries_ParentMasteryId",
                        column: x => x.ParentMasteryId,
                        principalTable: "Masteries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpellBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ManaCost = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
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
                name: "SpellMasteries",
                columns: table => new
                {
                    MasteryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellMasteries", x => new { x.MasteryId, x.SpellId });
                    table.ForeignKey(
                        name: "FK_SpellMasteries_Masteries_MasteryId",
                        column: x => x.MasteryId,
                        principalTable: "Masteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpellMasteries_Spells_SpellId",
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

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Incendiaire" });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Terrestre" });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Aérienne" });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Aquatique" });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Lumineuse" });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Lunaire" });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Ténébreuse" });

            migrationBuilder.InsertData(
                table: "Magics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Chaotique" });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 1, "Evocation", null });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 2, "Infusion", null });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 3, "Renforcement", null });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 4, "Psychique", null });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 5, "Invocation", 1 });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 6, "Transformation", 2 });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 7, "Transmogrification", 3 });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 8, "Illusion", 4 });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 9, "Conjuration", 5 });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 10, "Techno-Magie", 6 });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 11, "Corporalki", 7 });

            migrationBuilder.InsertData(
                table: "Masteries",
                columns: new[] { "Id", "Name", "ParentMasteryId" },
                values: new object[] { 12, "Projection", 8 });

            migrationBuilder.CreateIndex(
                name: "IX_Masteries_ParentMasteryId",
                table: "Masteries",
                column: "ParentMasteryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellAddOn_SpellId",
                table: "SpellAddOn",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellBookSpell_SpellId",
                table: "SpellBookSpell",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellMagics_SpellId",
                table: "SpellMagics",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellMasteries_SpellId",
                table: "SpellMasteries",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SpellBookId",
                table: "User",
                column: "SpellBookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMagics_UserId",
                table: "UserMagics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasteries_UserId",
                table: "UserMasteries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellAddOn");

            migrationBuilder.DropTable(
                name: "SpellBookSpell");

            migrationBuilder.DropTable(
                name: "SpellMagics");

            migrationBuilder.DropTable(
                name: "SpellMasteries");

            migrationBuilder.DropTable(
                name: "UserMagics");

            migrationBuilder.DropTable(
                name: "UserMasteries");

            migrationBuilder.DropTable(
                name: "AddOns");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Magics");

            migrationBuilder.DropTable(
                name: "Masteries");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SpellBooks");
        }
    }
}
