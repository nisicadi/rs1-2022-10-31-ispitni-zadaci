using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class nesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "korisnikId",
                table: "NovaUpisanaGodina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NovaUpisanaGodina_korisnikId",
                table: "NovaUpisanaGodina",
                column: "korisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_NovaUpisanaGodina_KorisnickiNalog_korisnikId",
                table: "NovaUpisanaGodina",
                column: "korisnikId",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NovaUpisanaGodina_KorisnickiNalog_korisnikId",
                table: "NovaUpisanaGodina");

            migrationBuilder.DropIndex(
                name: "IX_NovaUpisanaGodina_korisnikId",
                table: "NovaUpisanaGodina");

            migrationBuilder.DropColumn(
                name: "korisnikId",
                table: "NovaUpisanaGodina");
        }
    }
}
