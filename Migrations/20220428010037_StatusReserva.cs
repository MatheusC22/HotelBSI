using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApp.Migrations
{
    public partial class StatusReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusReservaID",
                table: "Reserva",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatusReserva",
                columns: table => new
                {
                    StatusReservaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusReserva", x => x.StatusReservaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_StatusReservaID",
                table: "Reserva",
                column: "StatusReservaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_StatusReserva_StatusReservaID",
                table: "Reserva",
                column: "StatusReservaID",
                principalTable: "StatusReserva",
                principalColumn: "StatusReservaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_StatusReserva_StatusReservaID",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "StatusReserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_StatusReservaID",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "StatusReservaID",
                table: "Reserva");
        }
    }
}
