using Microsoft.EntityFrameworkCore;
using MaisProdutos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaisProdutos.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Descricao).HasMaxLength(255);
        }   
    }
}