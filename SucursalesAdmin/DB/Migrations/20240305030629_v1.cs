using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    MonedaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.MonedaId);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonedaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sucursales_Monedas_MonedaId",
                        column: x => x.MonedaId,
                        principalTable: "Monedas",
                        principalColumn: "MonedaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_MonedaId",
                table: "Sucursales",
                column: "MonedaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Monedas");
        }
    }
}
