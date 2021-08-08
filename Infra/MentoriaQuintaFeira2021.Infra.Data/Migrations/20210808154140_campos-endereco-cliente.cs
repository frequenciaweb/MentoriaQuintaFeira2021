using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentoriaQuintaFeira2021.Infra.Data.Migrations
{
    public partial class camposenderecocliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_UF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ID", "Categoria", "Descricao", "Quantidade", "Valor" },
                values: new object[,]
                {
                    { 1, "BEBIDAS", "COCA COLA", 100, 3.50m },
                    { 2, "BEBIDAS", "CERVEJA", 100, 7.50m },
                    { 3, "BEBIDAS", "VINHO", 100, 13.50m },
                    { 4, "BEBIDAS", "CACHAÇA", 100, 1.50m },
                    { 5, "BISCOITO", "PASSATEMPO", 100, 3.50m },
                    { 6, "BISCOITO", "BONO", 100, 3.50m },
                    { 7, "LANCHES", "PIZZA", 100, 2.50m },
                    { 8, "LANCHES", "COXINHA", 100, 1.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteID",
                table: "Vendas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutoID",
                table: "Vendas",
                column: "ProdutoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
