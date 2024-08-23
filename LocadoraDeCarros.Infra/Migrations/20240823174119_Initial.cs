using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeCarros.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupoAutomoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoAutomoveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Foto = table.Column<string>(type: "varchar(250)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(150)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(150)", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "varchar(50)", nullable: false),
                    CapacidadeCombustivel = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ano = table.Column<string>(type: "varchar(150)", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAutomovel_TBGrupoAutomoveis_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBPlanos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plano = table.Column<string>(type: "varchar(100)", nullable: false),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecoKm = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    KmDisponivel = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    KmExtrapolado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanos_TBGrupoAutomoveis_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_GrupoId",
                table: "TBAutomovel",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanos_GrupoId",
                table: "TBPlanos",
                column: "GrupoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAutomovel");

            migrationBuilder.DropTable(
                name: "TBPlanos");

            migrationBuilder.DropTable(
                name: "TBGrupoAutomoveis");
        }
    }
}
