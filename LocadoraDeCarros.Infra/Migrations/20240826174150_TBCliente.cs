using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeCarros.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TBCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoCliente = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCliente");
        }
    }
}
