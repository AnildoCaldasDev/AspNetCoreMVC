using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMVC.Migrations
{
    public partial class initial_Filme_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 60, nullable: false),
                    Lancamento = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(maxLength: 30, nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Classificacao = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
