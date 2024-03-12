using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebColumnas.Migrations
{
    /// <inheritdoc />
    public partial class Analisismodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisis_ProductosPrincipios_ProductosPrincipiosProductoId_ProductosPrincipiosPrincipiosActivosId",
                table: "Analisis");

            migrationBuilder.DropIndex(
                name: "IX_Analisis_ProductosPrincipiosProductoId_ProductosPrincipiosPrincipiosActivosId",
                table: "Analisis");

            migrationBuilder.DropColumn(
                name: "PrincipiosActivosId",
                table: "Analisis");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Analisis");

            migrationBuilder.DropColumn(
                name: "ProductosPrincipiosPrincipiosActivosId",
                table: "Analisis");

            migrationBuilder.DropColumn(
                name: "ProductosPrincipiosProductoId",
                table: "Analisis");

            migrationBuilder.AddColumn<string>(
                name: "LoteId",
                table: "Analisis",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_LoteId",
                table: "Analisis",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisis_Lote_LoteId",
                table: "Analisis",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "LoteID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisis_Lote_LoteId",
                table: "Analisis");

            migrationBuilder.DropIndex(
                name: "IX_Analisis_LoteId",
                table: "Analisis");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "Analisis");

            migrationBuilder.AddColumn<int>(
                name: "PrincipiosActivosId",
                table: "Analisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Analisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductosPrincipiosPrincipiosActivosId",
                table: "Analisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductosPrincipiosProductoId",
                table: "Analisis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_ProductosPrincipiosProductoId_ProductosPrincipiosPrincipiosActivosId",
                table: "Analisis",
                columns: new[] { "ProductosPrincipiosProductoId", "ProductosPrincipiosPrincipiosActivosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Analisis_ProductosPrincipios_ProductosPrincipiosProductoId_ProductosPrincipiosPrincipiosActivosId",
                table: "Analisis",
                columns: new[] { "ProductosPrincipiosProductoId", "ProductosPrincipiosPrincipiosActivosId" },
                principalTable: "ProductosPrincipios",
                principalColumns: new[] { "ProductoId", "PrincipiosActivosId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
