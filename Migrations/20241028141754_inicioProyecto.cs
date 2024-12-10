using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendFinal.Migrations
{
    /// <inheritdoc />
    public partial class inicioProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CentrosDonacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosDonacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Donantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DNI = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FactorRH = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contacto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donantes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramasDonacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    CentroDonacionId = table.Column<int>(type: "int", nullable: false),
                    TipoSangreSolicitada = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramasDonacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramasDonacion_CentrosDonacion_CentroDonacionId",
                        column: x => x.CentroDonacionId,
                        principalTable: "CentrosDonacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Donaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DonanteId = table.Column<int>(type: "int", nullable: false),
                    FechaDonacion = table.Column<DateOnly>(type: "date", nullable: false),
                    TipoDonacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProgramaDonacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donaciones_Donantes_DonanteId",
                        column: x => x.DonanteId,
                        principalTable: "Donantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donaciones_ProgramasDonacion_ProgramaDonacionId",
                        column: x => x.ProgramaDonacionId,
                        principalTable: "ProgramasDonacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_DonanteId",
                table: "Donaciones",
                column: "DonanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_ProgramaDonacionId",
                table: "Donaciones",
                column: "ProgramaDonacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramasDonacion_CentroDonacionId",
                table: "ProgramasDonacion",
                column: "CentroDonacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donaciones");

            migrationBuilder.DropTable(
                name: "Donantes");

            migrationBuilder.DropTable(
                name: "ProgramasDonacion");

            migrationBuilder.DropTable(
                name: "CentrosDonacion");
        }
    }
}
