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
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
