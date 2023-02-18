using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datumOvjereZimskog",
                table: "UpisAkGodina",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "evidentiraoKorisnikId",
                table: "UpisAkGodina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodina_evidentiraoKorisnikId",
                table: "UpisAkGodina",
                column: "evidentiraoKorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisAkGodina_KorisnickiNalog_evidentiraoKorisnikId",
                table: "UpisAkGodina",
                column: "evidentiraoKorisnikId",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisAkGodina_KorisnickiNalog_evidentiraoKorisnikId",
                table: "UpisAkGodina");

            migrationBuilder.DropIndex(
                name: "IX_UpisAkGodina_evidentiraoKorisnikId",
                table: "UpisAkGodina");

            migrationBuilder.DropColumn(
                name: "datumOvjereZimskog",
                table: "UpisAkGodina");

            migrationBuilder.DropColumn(
                name: "evidentiraoKorisnikId",
                table: "UpisAkGodina");
        }
    }
}
