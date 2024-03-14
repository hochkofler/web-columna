using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebColumnas.Migrations
{
    /// <inheritdoc />
    public partial class StringLoteID2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisis_Columna_ColumnasColumnaId",
                table: "Analisis");

            migrationBuilder.DropIndex(
                name: "IX_Analisis_ColumnasColumnaId",
                table: "Analisis");

            migrationBuilder.DropColumn(
                name: "ColumnasColumnaId",
                table: "Analisis");

            migrationBuilder.AlterColumn<string>(
                name: "ColumnaId",
                table: "Analisis",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_ColumnaId",
                table: "Analisis",
                column: "ColumnaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisis_Columna_ColumnaId",
                table: "Analisis",
                column: "ColumnaId",
                principalTable: "Columna",
                principalColumn: "ColumnaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analisis_Columna_ColumnaId",
                table: "Analisis");

            migrationBuilder.DropIndex(
                name: "IX_Analisis_ColumnaId",
                table: "Analisis");

            migrationBuilder.AlterColumn<int>(
                name: "ColumnaId",
                table: "Analisis",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ColumnasColumnaId",
                table: "Analisis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_ColumnasColumnaId",
                table: "Analisis",
                column: "ColumnasColumnaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analisis_Columna_ColumnasColumnaId",
                table: "Analisis",
                column: "ColumnasColumnaId",
                principalTable: "Columna",
                principalColumn: "ColumnaId");
        }
    }
}
