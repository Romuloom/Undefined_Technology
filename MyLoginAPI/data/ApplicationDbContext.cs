using Microsoft.EntityFrameworkCore;
using MyLoginAPI.Models; // Certifique-se de que o namespace para os modelos esteja correto
using System;
using Microsoft.AspNetCore.Identity;

namespace MyLoginAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets para as entidades do sistema
        public DbSet<User> Users { get; set; } // Adicionado para a entidade User
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<ListaEscolar> ListasEscolares { get; set; }
        public DbSet<Metrica> Metricas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed para a entidade Pedido
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido { Id = 1, Valor = 200.00m, Data = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), FormaPagamento = "Dinheiro", Status = "Entregue" },
                new Pedido { Id = 2, Valor = 150.00m, Data = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), FormaPagamento = "Cartão de Crédito", Status = "Em preparação" }
            );

            // Seed para a entidade Estoque
            modelBuilder.Entity<Estoque>().HasData(
                new Estoque { Id = 1, NomeProduto = "Lápis", Quantidade = 100, QuantidadeMinima = 10 },
                new Estoque { Id = 2, NomeProduto = "Caderno", Quantidade = 50, QuantidadeMinima = 5 }
            );

            // Seed para a entidade ListaEscolar
            modelBuilder.Entity<ListaEscolar>().HasData(
                new ListaEscolar { Id = 1, NomeEscola = "Escola Primária A", Produtos = "Lápis, Caderno" },
                new ListaEscolar { Id = 2, NomeEscola = "Escola Secundária B", Produtos = "Borracha, Régua" }
            );

            // Seed para a entidade Metrica
            modelBuilder.Entity<Metrica>().HasData(
                new Metrica { Id = 1, TotalPedidosParaEntrega = 10, TotalProdutosCadastrados = 150, TotalProdutosEmEstoqueMinimo = 2, TotalNovosClientes = 5 }
            );

            // Seed para a entidade User
            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin@example.com",
                    Password = hasher.HashPassword(null, "Admin123!")
                }
            );
        }
    }
}
