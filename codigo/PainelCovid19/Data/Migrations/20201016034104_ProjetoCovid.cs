using Microsoft.EntityFrameworkCore.Migrations;

namespace PainelCovid19.Data.Migrations
{
    public partial class ProjetoCovid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "DadosCovid",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasosConfirmados = table.Column<int>(nullable: false),
                    Mortes = table.Column<int>(nullable: false),
                    Recuperados = table.Column<int>(nullable: false),
                    PaisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosCovid", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DadosCovid_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosCovid_PaisId",
                table: "DadosCovid",
                column: "PaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosCovid");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
