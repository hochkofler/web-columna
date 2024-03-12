using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebColumnas.Migrations
{
    /// <inheritdoc />
    public partial class modeloanalisis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
