using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeCarros.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TBConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBConfiguracoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gasolina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Diesel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Alcool = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConfiguracoes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TBConfiguracoes",
                columns: new[] { "Id", "Alcool", "Diesel", "Gas", "Gasolina" },
                values: new object[] { 1, 1.0m, 1.0m, 1.0m, 1.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBConfiguracoes");
        }
    }
}
