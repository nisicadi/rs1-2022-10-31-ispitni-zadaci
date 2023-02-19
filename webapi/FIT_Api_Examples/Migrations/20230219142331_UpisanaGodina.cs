using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Migrations
{
    public partial class UpisanaGodina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NovaUpisanaGodina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    datumUpisaZ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    godinaStudija = table.Column<int>(type: "int", nullable: false),
                    akademskaGodinaId = table.Column<int>(type: "int", nullable: false),
                    cijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    isObnova = table.Column<bool>(type: "bit", nullable: false),
                    datumOvjere = table.Column<DateTime>(type: "datetime2", nullable: true),
                    napomenaOvjera = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovaUpisanaGodina", x => x.id);
                    table.ForeignKey(
                        name: "FK_NovaUpisanaGodina_AkademskaGodina_akademskaGodinaId",
                        column: x => x.akademskaGodinaId,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovaUpisanaGodina_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovaUpisanaGodina_akademskaGodinaId",
                table: "NovaUpisanaGodina",
                column: "akademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_NovaUpisanaGodina_studentId",
                table: "NovaUpisanaGodina",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovaUpisanaGodina");
        }
    }
}
