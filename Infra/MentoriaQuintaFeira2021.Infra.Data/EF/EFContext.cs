using MentoriaQuintaFeira2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MentoriaQuintaFeira2021.Infra.Data.EF
{
    public class EFContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        public EFContext(){}
        public EFContext(DbContextOptions options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=PCDEV\SQLEXPRESS;Database=mentoria_quinta_feira;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(
                new Produto { ID = 1, Categoria = "BEBIDAS", Descricao = "COCA COLA", Quantidade = 100, Valor = 3.50M },
                new Produto { ID = 2, Categoria = "BEBIDAS", Descricao = "CERVEJA", Quantidade = 100, Valor = 7.50M },
                new Produto { ID = 3, Categoria = "BEBIDAS", Descricao = "VINHO", Quantidade = 100, Valor = 13.50M },
                new Produto { ID = 4, Categoria = "BEBIDAS", Descricao = "CACHAÇA", Quantidade = 100, Valor = 1.50M },
                new Produto { ID = 5, Categoria = "BISCOITO", Descricao = "PASSATEMPO", Quantidade = 100, Valor = 3.50M },
                new Produto { ID = 6, Categoria = "BISCOITO", Descricao = "BONO", Quantidade = 100, Valor = 3.50M },
                new Produto { ID = 7, Categoria = "LANCHES", Descricao = "PIZZA", Quantidade = 100, Valor = 2.50M },
                new Produto { ID = 8, Categoria = "LANCHES", Descricao = "COXINHA", Quantidade = 100, Valor = 1.00M }
            );

            modelBuilder.Entity<Cliente>().HasData(
               new Cliente { ID = 1, Nome = "JOSE DA SILVA" },
               new Cliente { ID = 2, Nome = "MARIA APARECIDA" },
               new Cliente { ID = 3, Nome = "CARLOS ANDRE" },
               new Cliente { ID = 4, Nome = "PAULO VELOSO" },
               new Cliente { ID = 5, Nome = "SERGIO CABRAL" }
           );
        }

    }
}
