using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonNow.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "ElectricalItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuarioId = table.Column<int>(type: "int", nullable: true),
                    NomeItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumoKwh = table.Column<int>(type: "int", nullable: false),
                    DtUso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmissaoCalculada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricalItems_Users_IdUsuarioId",
                        column: x => x.IdUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuarioId = table.Column<int>(type: "int", nullable: true),
                    TipoTransporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistanciaKm = table.Column<int>(type: "int", nullable: false),
                    DtUso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmissaoCalculada = table.Column<int>(type: "int", nullable: false),
                    EmissaoPermitidaIso = table.Column<int>(type: "int", nullable: false),
                    ConformeIso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transports_Users_IdUsuarioId",
                        column: x => x.IdUsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalItems_IdUsuarioId",
                table: "ElectricalItems",
                column: "IdUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_IdUsuarioId",
                table: "Transports",
                column: "IdUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricalItems");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
