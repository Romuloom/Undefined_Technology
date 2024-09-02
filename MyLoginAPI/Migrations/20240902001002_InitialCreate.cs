using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyLoginAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeProduto = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeMinima = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListasEscolares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeEscola = table.Column<string>(type: "text", nullable: false),
                    Produtos = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasEscolares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metricas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalPedidosParaEntrega = table.Column<int>(type: "integer", nullable: false),
                    TotalProdutosCadastrados = table.Column<int>(type: "integer", nullable: false),
                    TotalProdutosEmEstoqueMinimo = table.Column<int>(type: "integer", nullable: false),
                    TotalNovosClientes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metricas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FormaPagamento = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Estoques",
                columns: new[] { "Id", "NomeProduto", "Quantidade", "QuantidadeMinima" },
                values: new object[,]
                {
                    { 1, "Lápis", 100, 10 },
                    { 2, "Caderno", 50, 5 }
                });

            migrationBuilder.InsertData(
                table: "ListasEscolares",
                columns: new[] { "Id", "NomeEscola", "Produtos" },
                values: new object[,]
                {
                    { 1, "Escola Primária A", "Lápis, Caderno" },
                    { 2, "Escola Secundária B", "Borracha, Régua" }
                });

            migrationBuilder.InsertData(
                table: "Metricas",
                columns: new[] { "Id", "TotalNovosClientes", "TotalPedidosParaEntrega", "TotalProdutosCadastrados", "TotalProdutosEmEstoqueMinimo" },
                values: new object[] { 1, 5, 10, 150, 2 });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "Data", "FormaPagamento", "Status", "Valor" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 0, 10, 2, 466, DateTimeKind.Utc).AddTicks(2058), "Dinheiro", "Entregue", 200.00m },
                    { 2, new DateTime(2024, 9, 2, 0, 10, 2, 466, DateTimeKind.Utc).AddTicks(2062), "Cartão de Crédito", "Em preparação", 150.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "ListasEscolares");

            migrationBuilder.DropTable(
                name: "Metricas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
