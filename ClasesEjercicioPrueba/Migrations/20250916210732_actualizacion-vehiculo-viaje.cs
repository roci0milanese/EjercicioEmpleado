using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClasesEjercicioPrueba.Migrations
{
    /// <inheritdoc />
    public partial class actualizacionvehiculoviaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "motor",
                table: "vehiculos");

            migrationBuilder.DropColumn(
                name: "tieneAuxiliar",
                table: "vehiculos");

            migrationBuilder.RenameColumn(
                name: "patente",
                table: "vehiculos",
                newName: "Patente");

            migrationBuilder.RenameColumn(
                name: "modelo",
                table: "vehiculos",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "marca",
                table: "vehiculos",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "vehiculos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "cantidadPuertas",
                table: "vehiculos",
                newName: "CapacidadCargaKg");

            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanciaKm = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viaje");

            migrationBuilder.RenameColumn(
                name: "Patente",
                table: "vehiculos",
                newName: "patente");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "vehiculos",
                newName: "modelo");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "vehiculos",
                newName: "marca");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "vehiculos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CapacidadCargaKg",
                table: "vehiculos",
                newName: "cantidadPuertas");

            migrationBuilder.AddColumn<string>(
                name: "motor",
                table: "vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "tieneAuxiliar",
                table: "vehiculos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
