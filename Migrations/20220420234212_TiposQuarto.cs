using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApp.Migrations
{
    public partial class TiposQuarto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoQuarto",
                table: "Quarto");

            migrationBuilder.AddColumn<int>(
                name: "TipoQuartoID",
                table: "Quarto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    TipoQuartoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Preco = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuarto", x => x.TipoQuartoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quarto_TipoQuartoID",
                table: "Quarto",
                column: "TipoQuartoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quarto_TipoQuarto_TipoQuartoID",
                table: "Quarto",
                column: "TipoQuartoID",
                principalTable: "TipoQuarto",
                principalColumn: "TipoQuartoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quarto_TipoQuarto_TipoQuartoID",
                table: "Quarto");

            migrationBuilder.DropTable(
                name: "TipoQuarto");

            migrationBuilder.DropIndex(
                name: "IX_Quarto_TipoQuartoID",
                table: "Quarto");

            migrationBuilder.DropColumn(
                name: "TipoQuartoID",
                table: "Quarto");

            migrationBuilder.AddColumn<string>(
                name: "TipoQuarto",
                table: "Quarto",
                type: "TEXT",
                nullable: true);
        }
    }
}
