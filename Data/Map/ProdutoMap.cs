using Microsoft.EntityFrameworkCore;
using MaisProdutos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaisProdutos.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255);
        }
    }
}
