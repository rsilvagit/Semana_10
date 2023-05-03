using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locacao.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MARCA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CARRO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATA_LOCACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarcaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARRO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CARRO_MARCA_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "MARCA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CARRO_MarcaID",
                table: "CARRO",
                column: "MarcaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CARRO");

            migrationBuilder.DropTable(
                name: "MARCA");
        }
    }
}
