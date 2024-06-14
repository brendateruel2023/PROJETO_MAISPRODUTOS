using System.ComponentModel;

namespace MaisProdutos.Enums
{
    public enum StatusProduto
    {
        [Description("Em Estoque")]
        EmEstoque = 1,
        [Description("Fora de Estoque")]
        ForaDeEstoque = 2
    }
}
