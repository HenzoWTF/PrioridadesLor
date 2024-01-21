using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrioridadesLor.Migrations
{
    /// <inheritdoc />
    public partial class Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: true),
                    CelularCliente = table.Column<string>(type: "TEXT", nullable: true),
                    TelefonoCliente = table.Column<string>(type: "TEXT", nullable: true),
                    RNC = table.Column<string>(type: "TEXT", nullable: true),
                    EmailCliente = table.Column<string>(type: "TEXT", nullable: true),
                    DireccionCliente = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientesID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
