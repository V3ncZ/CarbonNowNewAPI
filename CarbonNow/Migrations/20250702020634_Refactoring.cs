using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonNow.Migrations
{
    /// <inheritdoc />
    public partial class Refactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Users_IdUsuarioId",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "ConformeIso",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "TipoTransporte",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "NomeItem",
                table: "ElectricalItems");

            migrationBuilder.RenameColumn(
                name: "EmissaoPermitidaIso",
                table: "Transports",
                newName: "TipoTransporteId");

            migrationBuilder.RenameColumn(
                name: "ConsumoKwh",
                table: "ElectricalItems",
                newName: "TipoItemEletricoId");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuarioId",
                table: "Transports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "EmissaoCalculada",
                table: "Transports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "DistanciaKm",
                table: "Transports",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "EmissaoCalculada",
                table: "ElectricalItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "DuracaoUsoHoras",
                table: "ElectricalItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ElectricalItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumoKwhPorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmissaoFatorPorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConformeIso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TipoTransporteId",
                table: "Transports",
                column: "TipoTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalItems_TipoItemEletricoId",
                table: "ElectricalItems",
                column: "TipoItemEletricoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricalItems_ElectricalItemType_TipoItemEletricoId",
                table: "ElectricalItems",
                column: "TipoItemEletricoId",
                principalTable: "ElectricalItemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TransportType_TipoTransporteId",
                table: "Transports",
                column: "TipoTransporteId",
                principalTable: "TransportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Users_IdUsuarioId",
                table: "Transports",
                column: "IdUsuarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectricalItems_ElectricalItemType_TipoItemEletricoId",
                table: "ElectricalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportType_TipoTransporteId",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Users_IdUsuarioId",
                table: "Transports");

            migrationBuilder.DropTable(
                name: "ElectricalItemType");

            migrationBuilder.DropTable(
                name: "TransportType");

            migrationBuilder.DropIndex(
                name: "IX_Transports_TipoTransporteId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_ElectricalItems_TipoItemEletricoId",
                table: "ElectricalItems");

            migrationBuilder.DropColumn(
                name: "DuracaoUsoHoras",
                table: "ElectricalItems");

            migrationBuilder.RenameColumn(
                name: "TipoTransporteId",
                table: "Transports",
                newName: "EmissaoPermitidaIso");

            migrationBuilder.RenameColumn(
                name: "TipoItemEletricoId",
                table: "ElectricalItems",
                newName: "ConsumoKwh");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuarioId",
                table: "Transports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmissaoCalculada",
                table: "Transports",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "DistanciaKm",
                table: "Transports",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "ConformeIso",
                table: "Transports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TipoTransporte",
                table: "Transports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmissaoCalculada",
                table: "ElectricalItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "NomeItem",
                table: "ElectricalItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Users_IdUsuarioId",
                table: "Transports",
                column: "IdUsuarioId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
