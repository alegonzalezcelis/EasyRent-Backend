using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace contactos.Migrations
{
    public partial class Departamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    descripcion = table.Column<string>(nullable: true),
                    tamanio = table.Column<string>(nullable: true),
                    ubicacion = table.Column<string>(nullable: true),
                    precio = table.Column<string>(nullable: true),
                    condiciones = table.Column<string>(nullable: true),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
