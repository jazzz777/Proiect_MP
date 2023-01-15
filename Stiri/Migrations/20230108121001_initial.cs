using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stiri.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cititor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cititor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jurnalist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurnalist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articol",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text_Articol = table.Column<long>(type: "bigint", nullable: false),
                    Aprobat = table.Column<bool>(type: "bit", nullable: false),
                    JurnalistID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articol", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articol_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articol_Jurnalist_JurnalistID",
                        column: x => x.JurnalistID,
                        principalTable: "Jurnalist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articol_CategorieID",
                table: "Articol",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Articol_JurnalistID",
                table: "Articol",
                column: "JurnalistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articol");

            migrationBuilder.DropTable(
                name: "Cititor");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Jurnalist");
        }
    }
}
