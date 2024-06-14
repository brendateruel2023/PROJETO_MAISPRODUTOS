using MaisProdutos.Enums;

namespace MaisProdutos.Models.Dtos
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public required int CategoriaId { get; set; }
        public string? Descricao { get; set; }
        public StatusProduto Status { get; set; }
    }
}