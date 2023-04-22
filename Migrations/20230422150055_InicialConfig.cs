using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webveiculos.Migrations
{
    /// <inheritdoc />
    public partial class InicialConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdPortas = table.Column<int>(type: "INT", nullable: false),
                    LitragemPortaMalas = table.Column<int>(type: "INT", nullable: false),
                    Marca = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Ano = table.Column<int>(type: "INT", nullable: false),
                    Modelo = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Cor = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Placa = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Combustivel = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onibus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdAssentos = table.Column<int>(type: "INT", nullable: false),
                    PossuiBanheiro = table.Column<bool>(type: "BIT", nullable: false),
                    PossuiWifi = table.Column<bool>(type: "BIT", nullable: false),
                    PossuiTomada = table.Column<bool>(type: "BIT", nullable: false),
                    PossuiTv = table.Column<bool>(type: "BIT", nullable: false),
                    Marca = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Ano = table.Column<int>(type: "INT", nullable: false),
                    Modelo = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    Combustivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onibus", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Onibus");
        }
    }
}
