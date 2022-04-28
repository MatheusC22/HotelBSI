using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApp.Migrations
{
    public partial class StatusQuarto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusQuarto",
                table: "Quarto");

            migrationBuilder.AddColumn<int>(
                name: "StatusQuartoID",
                table: "Quarto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StatusQuarto",
                columns: table => new
                {
                    StatusQuartoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusQuarto", x => x.StatusQuartoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_StatusQuartoID",
                table: "Quarto",
                column: "StatusQuartoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quarto_StatusQuarto_StatusQuartoID",
                table: "Quarto",
                column: "StatusQuartoID",
                principalTable: "StatusQuarto",
                principalColumn: "StatusQuartoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quarto_StatusQuarto_StatusQuartoID",
                table: "Quarto");

            migrationBuilder.DropTable(
                name: "StatusQuarto");

            migrationBuilder.DropIndex(
                name: "IX_Quarto_StatusQuartoID",
                table: "Quarto");

            migrationBuilder.DropColumn(
                name: "StatusQuartoID",
                table: "Quarto");

            migrationBuilder.AddColumn<string>(
                name: "StatusQuarto",
                table: "Quarto",
                type: "TEXT",
                nullable: true);
        }
    }
}
