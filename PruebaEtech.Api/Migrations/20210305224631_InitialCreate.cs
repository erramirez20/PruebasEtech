using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaEtech.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    IdViaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoViaje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LugaresDisponibles = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.IdViaje);
                });

            migrationBuilder.CreateTable(
                name: "Viajero",
                columns: table => new
                {
                    IdViajero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajero", x => x.IdViajero);
                });

            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    IdReservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdViaje = table.Column<int>(type: "int", nullable: false),
                    IdViajero = table.Column<int>(type: "int", nullable: false),
                    Asientos = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.IdReservacion);
                    table.ForeignKey(
                        name: "FK_Reservacion_Viaje",
                        column: x => x.IdViaje,
                        principalTable: "Viaje",
                        principalColumn: "IdViaje",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservacion_Viajero",
                        column: x => x.IdViajero,
                        principalTable: "Viajero",
                        principalColumn: "IdViajero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_IdViaje",
                table: "Reservacion",
                column: "IdViaje");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_IdViajero",
                table: "Reservacion",
                column: "IdViajero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "Viaje");

            migrationBuilder.DropTable(
                name: "Viajero");
        }
    }
}
