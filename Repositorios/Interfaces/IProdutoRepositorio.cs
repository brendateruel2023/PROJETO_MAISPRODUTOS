using MaisProdutos.Models;
using MaisProdutos.Models.Dtos;

namespace MaisProdutos.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> BuscarPorId(int id);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoDto produto, int id);
        Task<bool> Deletar(int id);
    }
}
