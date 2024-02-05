using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrioridadesLor.Migrations
{
    /// <inheritdoc />
    public partial class Clientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClientesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombresClientes = table.Column<string>(type: "TEXT", nullable: false),
                    CelularClientes = table.Column<string>(type: "TEXT", nullable: false),
                    TelefonoClientes = table.Column<string>(type: "TEXT", nullable: false),
                    RNC = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    EmailClientes = table.Column<string>(type: "TEXT", nullable: false),
                    DireccionClientes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClientesID);
                });

            migrationBuilder.CreateTable(
                name: "prioridades",
                columns: table => new
                {
                    IdPrioridades = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    DiasCompromiso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prioridades", x => x.IdPrioridades);
                });

            migrationBuilder.CreateTable(
                name: "sistemas",
                columns: table => new
                {
                    SistemasId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SistemasNombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sistemas", x => x.SistemasId);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    TicketsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SistemasId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrioridadesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SolicitadoPor = table.Column<string>(type: "TEXT", nullable: false),
                    Asunto = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.TicketsId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "prioridades");

            migrationBuilder.DropTable(
                name: "sistemas");

            migrationBuilder.DropTable(
                name: "tickets");
        }
    }
}
