﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArabaSatis.Migrations
{
    /// <inheritdoc />
    public partial class Seriler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YakitTuru",
                table: "Yakits");

            migrationBuilder.AlterColumn<string>(
                name: "YakitAdi",
                table: "Yakits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "SeriModels",
                columns: table => new
                {
                    SeriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: true),
                    MarkalarsMarkaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriModels", x => x.SeriId);
                    table.ForeignKey(
                        name: "FK_SeriModels_Markalars_MarkalarsMarkaId",
                        column: x => x.MarkalarsMarkaId,
                        principalTable: "Markalars",
                        principalColumn: "MarkaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriModels_MarkalarsMarkaId",
                table: "SeriModels",
                column: "MarkalarsMarkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriModels");

            migrationBuilder.AlterColumn<int>(
                name: "YakitAdi",
                table: "Yakits",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "YakitTuru",
                table: "Yakits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
