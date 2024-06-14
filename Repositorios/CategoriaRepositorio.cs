using Microsoft.EntityFrameworkCore;
using MaisProdutos.Data;
using MaisProdutos.Models;
using MaisProdutos.Repositorios.Interfaces;

namespace MaisProdutos.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ProdutosDbContext _DbContext;

        public CategoriaRepositorio(ProdutosDbContext produtosDbContext)
        {
            _DbContext = produtosDbContext;
        }

        public async Task<CategoriaModel> BuscarPorId(int id)
        {
            return await _DbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriaModel>> BuscarProdutos()
        {
            return await _DbContext.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
        {
            await _DbContext.Categorias.AddAsync(categoria);
            await _DbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria de Id: {id} não foi encontrado.");
            }

            categoriaPorId.Nome = categoria.Nome;
            categoriaPorId.Descricao = categoria.Descricao;

            _DbContext.Categorias.Update(categoriaPorId);
            await _DbContext.SaveChangesAsync();

            return categoriaPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            CategoriaModel categoriaPorId = await BuscarPorId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria de Id: {id} não foi encontrado.");
            }

            _DbContext.Categorias.Remove(categoriaPorId);
            await _DbContext.SaveChangesAsync();

            return true;
        }

        public Task<List<CategoriaModel>> BuscarCategorias()
        {
            List<CategoriaModel> categorias = _DbContext.Categorias.ToList();
            return Task.FromResult(categorias);
        }
    }
}
