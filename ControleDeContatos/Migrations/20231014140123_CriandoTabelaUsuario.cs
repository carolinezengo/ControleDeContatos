using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Usuario",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  Perfil = table.Column<int>(type: "int", nullable: false),
                 Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                  DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Usuario", x => x.Id);
              });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Usuario");
        }
    }
}
