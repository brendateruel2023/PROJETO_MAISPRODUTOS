using MaisProdutos.Models;

namespace MaisProdutos.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModel>> BuscarCategorias();
        Task<CategoriaModel> BuscarPorId(int id);
        Task<CategoriaModel> Adicionar(CategoriaModel categoria);
        Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id);
        Task<bool> Deletar(int id);
    }
}
