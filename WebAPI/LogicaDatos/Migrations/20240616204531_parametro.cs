using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaDatos.Migrations
{
    /// <inheritdoc />
    public partial class parametro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametroArticulos");

            migrationBuilder.AddColumn<int>(
                name: "ParametroId",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopeMovimiento_Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_ParametroId",
                table: "Articulos",
                column: "ParametroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Parametros_ParametroId",
                table: "Articulos",
                column: "ParametroId",
                principalTable: "Parametros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Parametros_ParametroId",
                table: "Articulos");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_ParametroId",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "ParametroId",
                table: "Articulos");

            migrationBuilder.CreateTable(
                name: "ParametroArticulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    TopeMovimiento_Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroArticulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametroArticulos_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParametroArticulos_ArticuloId",
                table: "ParametroArticulos",
                column: "ArticuloId",
                unique: true);
        }
    }
}
