using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebColumnas.Migrations
{
    /// <inheritdoc />
    public partial class newmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrincipiosActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipiosActivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    LoteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVcto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TamanoObjetivo = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.LoteID);
                    table.ForeignKey(
                        name: "FK_Lote_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrincipiosActivosProducto",
                columns: table => new
                {
                    PrincipiosActivosId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipiosActivosProducto", x => new { x.PrincipiosActivosId, x.ProductosId });
                    table.ForeignKey(
                        name: "FK_PrincipiosActivosProducto_PrincipiosActivos_PrincipiosActivosId",
                        column: x => x.PrincipiosActivosId,
                        principalTable: "PrincipiosActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrincipiosActivosProducto_Producto_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosPrincipios",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrincipiosActivosId = table.Column<int>(type: "int", nullable: false),
                    Concentracion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosPrincipios", x => new { x.ProductoId, x.PrincipiosActivosId });
                    table.ForeignKey(
                        name: "FK_ProductosPrincipios_PrincipiosActivos_PrincipiosActivosId",
                        column: x => x.PrincipiosActivosId,
                        principalTable: "PrincipiosActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosPrincipios_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ph = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Presion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiempoCorrida = table.Column<TimeOnly>(type: "time", nullable: false),
                    Flujo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Temperatura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresionIni = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresionFin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrincipiosActivosId = table.Column<int>(type: "int", nullable: false),
                    ProductosPrincipiosProductoId = table.Column<int>(type: "int", nullable: false),
                    ProductosPrincipiosPrincipiosActivosId = table.Column<int>(type: "int", nullable: false),
                    ColumnaId = table.Column<int>(type: "int", nullable: false),
                    ColumnasColumnaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analisis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analisis_Columna_ColumnasColumnaId",
                        column: x => x.ColumnasColumnaId,
                        principalTable: "Columna",
                        principalColumn: "ColumnaId");
                    table.ForeignKey(
                        name: "FK_Analisis_ProductosPrincipios_ProductosPrincipiosProductoId_ProductosPrincipiosPrincipiosActivosId",
                        columns: x => new { x.ProductosPrincipiosProductoId, x.ProductosPrincipiosPrincipiosActivosId },
                        principalTable: "ProductosPrincipios",
                        principalColumns: new[] { "ProductoId", "PrincipiosActivosId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_ColumnasColumnaId",
                table: "Analisis",
                column: "ColumnasColumnaId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_ProductosPrincipiosProductoId_ProductosPrincipiosPrincipiosActivosId",
                table: "Analisis",
                columns: new[] { "ProductosPrincipiosProductoId", "ProductosPrincipiosPrincipiosActivosId" });

            migrationBuilder.CreateIndex(
                name: "IX_Lote_ProductoId",
                table: "Lote",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipiosActivosProducto_ProductosId",
                table: "PrincipiosActivosProducto",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosPrincipios_PrincipiosActivosId",
                table: "ProductosPrincipios",
                column: "PrincipiosActivosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analisis");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "PrincipiosActivosProducto");

            migrationBuilder.DropTable(
                name: "ProductosPrincipios");

            migrationBuilder.DropTable(
                name: "PrincipiosActivos");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
