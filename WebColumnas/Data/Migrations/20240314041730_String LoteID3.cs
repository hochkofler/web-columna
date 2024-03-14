using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebColumnas.Migrations
{
    /// <inheritdoc />
    public partial class StringLoteID3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrincipiosActivos_Analisis_AnalisisId",
                table: "PrincipiosActivos");

            migrationBuilder.DropIndex(
                name: "IX_PrincipiosActivos_AnalisisId",
                table: "PrincipiosActivos");

            migrationBuilder.DropColumn(
                name: "AnalisisId",
                table: "PrincipiosActivos");

            migrationBuilder.CreateTable(
                name: "AnalisisPrincipiosActivos",
                columns: table => new
                {
                    AnalisisId = table.Column<int>(type: "int", nullable: false),
                    PrincipiosActivosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisisPrincipiosActivos", x => new { x.AnalisisId, x.PrincipiosActivosId });
                    table.ForeignKey(
                        name: "FK_AnalisisPrincipiosActivos_Analisis_AnalisisId",
                        column: x => x.AnalisisId,
                        principalTable: "Analisis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisisPrincipiosActivos_PrincipiosActivos_PrincipiosActivosId",
                        column: x => x.PrincipiosActivosId,
                        principalTable: "PrincipiosActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisPrincipiosActivos_PrincipiosActivosId",
                table: "AnalisisPrincipiosActivos",
                column: "PrincipiosActivosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisisPrincipiosActivos");

            migrationBuilder.AddColumn<int>(
                name: "AnalisisId",
                table: "PrincipiosActivos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrincipiosActivos_AnalisisId",
                table: "PrincipiosActivos",
                column: "AnalisisId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrincipiosActivos_Analisis_AnalisisId",
                table: "PrincipiosActivos",
                column: "AnalisisId",
                principalTable: "Analisis",
                principalColumn: "Id");
        }
    }
}
