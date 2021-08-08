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
            modelBuilder
                .Entity<Cliente>()
                .OwnsOne(x => x.Endereco);
        }

    }
}
