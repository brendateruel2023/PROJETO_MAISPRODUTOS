using Microsoft.EntityFrameworkCore;
using MaisProdutos.Models;
using MaisProdutos.Data.Map;

namespace MaisProdutos.Data
{
    public class ProdutosDbContext : DbContext
    {
        public ProdutosDbContext(DbContextOptions<ProdutosDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}