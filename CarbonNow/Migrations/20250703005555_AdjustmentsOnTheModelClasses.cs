using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarbonNow.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentsOnTheModelClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectricalItems_Users_IdUsuarioId",
                table: "ElectricalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportType_TipoTransporteId",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Users_IdUsuarioId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_TipoTransporteId",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_ElectricalItems_IdUsuarioId",
                table: "ElectricalItems");

            migrationBuilder.DropColumn(
                name: "IdUsuarioId",
                table: "ElectricalItems");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioId",
                table: "Transports",
                newName: "TipoTransportId");

            migrationBuilder.RenameIndex(
                name: "IX_Transports_IdUsuarioId",
                table: "Transports",
                newName: "IX_Transports_TipoTransportId");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Transports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "ElectricalItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transports_IdUsuario",
                table: "Transports",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalItems_IdUsuario",
                table: "ElectricalItems",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricalItems_Users_IdUsuario",
                table: "ElectricalItems",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_TransportType_TipoTransportId",
                table: "Transports",
                column: "TipoTransportId",
                principalTable: "TransportType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Users_IdUsuario",
                table: "Transports",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElectricalItems_Users_IdUsuario",
                table: "ElectricalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_TransportType_TipoTransportId",
                table: "Transports");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Users_IdUsuario",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Transports_IdUsuario",
                table: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_ElectricalItems_IdUsuario",
                table: "ElectricalItems");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "ElectricalItems");

            migrationBuilder.RenameColumn(
                name: "TipoTransportId",
                table: "Transports",
                newName: "IdUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Transports_TipoTransportId",
                table: "Transports",
                newName: "IX_Transports_IdUsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioId",
                table: "ElectricalItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transports_TipoTransporteId",
                table: "Transports",
                column: "TipoTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalItems_IdUsuarioId",
                table: "ElectricalItems",
                column: "IdUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricalItems_Users_IdUsuarioId",
                table: "ElectricalItems",
                column: "IdUsuarioId",
                principalTable: "Users",
                principalColumn: "Id");

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
    }
}
