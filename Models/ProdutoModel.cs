using MaisProdutos.Enums;
using MaisProdutos.Models.Dtos;

namespace MaisProdutos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public required CategoriaModel Categoria { get; set; }
        public string? Descricao { get; set; }
        public StatusProduto Status { get; set; }
    }
}
