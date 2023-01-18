﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stiri.Migrations
{
    public partial class Add_userid_Cititor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articol_Categorie_CategorieID",
                table: "Articol");

            migrationBuilder.DropForeignKey(
                name: "FK_Articol_Jurnalist_JurnalistID",
                table: "Articol");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Cititor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JurnalistID",
                table: "Articol",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategorieID",
                table: "Articol",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articol_Categorie_CategorieID",
                table: "Articol",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articol_Jurnalist_JurnalistID",
                table: "Articol",
                column: "JurnalistID",
                principalTable: "Jurnalist",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articol_Categorie_CategorieID",
                table: "Articol");

            migrationBuilder.DropForeignKey(
                name: "FK_Articol_Jurnalist_JurnalistID",
                table: "Articol");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Cititor");

            migrationBuilder.AlterColumn<int>(
                name: "JurnalistID",
                table: "Articol",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieID",
                table: "Articol",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Articol_Categorie_CategorieID",
                table: "Articol",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articol_Jurnalist_JurnalistID",
                table: "Articol",
                column: "JurnalistID",
                principalTable: "Jurnalist",
                principalColumn: "ID");
        }
    }
}
