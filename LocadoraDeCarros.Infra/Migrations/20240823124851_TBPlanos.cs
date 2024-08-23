using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeCarros.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TBPlanos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plano = table.Column<string>(type: "varchar(100)", nullable: false),
                    PrecoDiaria = table.Column<string>(type: "varchar(100)", nullable: false),
                    PrecoKm = table.Column<string>(type: "varchar(100)", nullable: false),
                    KmDisponivel = table.Column<string>(type: "varchar(100)", nullable: false),
                    KmExtrapolado = table.Column<string>(type: "varchar(100)", nullable: false),
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
                name: "IX_TBPlanos_GrupoId",
                table: "TBPlanos",
                column: "GrupoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanos");
        }
    }
}
