using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApp.Migrations
{
    public partial class TabelaReservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    QuartoID = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCheckIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataCheckOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Quarto_QuartoID",
                        column: x => x.QuartoID,
                        principalTable: "Quarto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteID",
                table: "Reserva",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_QuartoID",
                table: "Reserva",
                column: "QuartoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");
        }
    }
}
