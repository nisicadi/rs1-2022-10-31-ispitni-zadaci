using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class korisnikId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "korisnikId",
                table: "UpisAkGodina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodina_korisnikId",
                table: "UpisAkGodina",
                column: "korisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisAkGodina_KorisnickiNalog_korisnikId",
                table: "UpisAkGodina",
                column: "korisnikId",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisAkGodina_KorisnickiNalog_korisnikId",
                table: "UpisAkGodina");

            migrationBuilder.DropIndex(
                name: "IX_UpisAkGodina_korisnikId",
                table: "UpisAkGodina");

            migrationBuilder.DropColumn(
                name: "korisnikId",
                table: "UpisAkGodina");
        }
    }
}
