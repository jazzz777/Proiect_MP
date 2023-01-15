using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stiri.Migrations
{
    public partial class categorii_plus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articole_Jurnalist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticolID = table.Column<int>(type: "int", nullable: false),
                    JurnalistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articole_Jurnalist", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articole_Jurnalist_Articol_ArticolID",
                        column: x => x.ArticolID,
                        principalTable: "Articol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorii_Articole",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticolID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorii_Articole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categorii_Articole_Articol_ArticolID",
                        column: x => x.ArticolID,
                        principalTable: "Articol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articole_Jurnalist_ArticolID",
                table: "Articole_Jurnalist",
                column: "ArticolID");

            migrationBuilder.CreateIndex(
                name: "IX_Articole_Jurnalist_JurnalistID",
                table: "Articole_Jurnalist",
                column: "JurnalistID");

            migrationBuilder.CreateIndex(
                name: "IX_Categorii_Articole_ArticolID",
                table: "Categorii_Articole",
                column: "ArticolID");

            migrationBuilder.CreateIndex(
                name: "IX_Categorii_Articole_CategorieID",
                table: "Categorii_Articole",
                column: "CategorieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articole_Jurnalist");

            migrationBuilder.DropTable(
                name: "Categorii_Articole");
        }
    }
}
