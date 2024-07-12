using Microsoft.EntityFrameworkCore;
using SistemaWeb.Shared.Models;

namespace SistemaWeb.Api.Context
{
    public class AppWebDbContext : DbContext
    {
        public AppWebDbContext(DbContextOptions<AppWebDbContext> dbContext) : base(dbContext) { }

        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ValidationFluentAPI
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired();

                entity.Property(e => e.Marca)
                    .IsRequired();

                entity.Property(e => e.Unidade)
                    .IsRequired();
                
                entity.Property(e => e.ValorCompra)
                    .IsRequired();
            }); 
            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired();

                entity.Property(e => e.Endereco)
                    .IsRequired();

                entity.Property(e => e.Cep)
                    .IsRequired();

                entity.Property(e => e.Cnpj)
                    .IsRequired();
                
                
                entity.Property(e => e.Telefone)
                    .IsRequired();
            });
            #endregion
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
