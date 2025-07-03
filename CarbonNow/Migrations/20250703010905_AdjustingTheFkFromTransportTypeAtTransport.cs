using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonNow.Migrations
{
    /// <inheritdoc />
    public partial class AdjustingTheFkFromTransportTypeAtTransport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportType_TipoTransportId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_TipoTransportId",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "TipoTransportId",
                table: "Transports");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TipoTransporteId",
                table: "Transports",
                column: "TipoTransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TransportType_TipoTransporteId",
                table: "Transports",
                column: "TipoTransporteId",
                principalTable: "TransportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportType_TipoTransporteId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_TipoTransporteId",
                table: "Transports");

            migrationBuilder.AddColumn<int>(
                name: "TipoTransportId",
                table: "Transports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TipoTransportId",
                table: "Transports",
                column: "TipoTransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TransportType_TipoTransportId",
                table: "Transports",
                column: "TipoTransportId",
                principalTable: "TransportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
