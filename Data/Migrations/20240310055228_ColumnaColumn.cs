using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebColumnas.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Columna",
                columns: table => new
                {
                    ColumnaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEnMarcha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaseEstacionaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresionMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columna", x => x.ColumnaId);
                    table.ForeignKey(
                        name: "FK_Columna_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaseMovil",
                columns: table => new
                {
                    FaseMovilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaseMovil", x => x.FaseMovilID);
                });

            migrationBuilder.CreateTable(
                name: "ColumnaFaseMovil",
                columns: table => new
                {
                    ColumnasColumnaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FasesMovilesFaseMovilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnaFaseMovil", x => new { x.ColumnasColumnaId, x.FasesMovilesFaseMovilID });
                    table.ForeignKey(
                        name: "FK_ColumnaFaseMovil_Columna_ColumnasColumnaId",
                        column: x => x.ColumnasColumnaId,
                        principalTable: "Columna",
                        principalColumn: "ColumnaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnaFaseMovil_FaseMovil_FasesMovilesFaseMovilID",
                        column: x => x.FasesMovilesFaseMovilID,
                        principalTable: "FaseMovil",
                        principalColumn: "FaseMovilID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Columna_MarcaId",
                table: "Columna",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnaFaseMovil_FasesMovilesFaseMovilID",
                table: "ColumnaFaseMovil",
                column: "FasesMovilesFaseMovilID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnaFaseMovil");

            migrationBuilder.DropTable(
                name: "Columna");

            migrationBuilder.DropTable(
                name: "FaseMovil");
        }
    }
}
