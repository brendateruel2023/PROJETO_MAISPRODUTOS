using Microsoft.EntityFrameworkCore;
using MaisProdutos.Data;
using MaisProdutos.Models;
using MaisProdutos.Repositorios.Interfaces;
using MaisProdutos.Models.Dtos;

namespace MaisProdutos.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ProdutosDbContext _DbContext;  

        public ProdutoRepositorio(ProdutosDbContext produtosDbContext) 
        {
            _DbContext = produtosDbContext;
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _DbContext.Produtos.Include(x => x.Categoria).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarProdutos()
        {
            return await _DbContext.Produtos.Include(x => x.Categoria).ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _DbContext.Produtos.AddAsync(produto);
            await _DbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoDto produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Produto de Id: {id} não foi encontrado.");
            }

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Preco = produto.Preco;
            produtoPorId.Quantidade = produto.Quantidade;
            produtoPorId.Categoria = _DbContext.Categorias.FirstOrDefault(x => x.Id == produto.CategoriaId);
            produtoPorId.Status = produto.Status;

            _DbContext.Produtos.Update(produtoPorId);
            await _DbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Deletar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Produto de Id: {id} não foi encontrado.");
            }

            _DbContext.Produtos.Remove(produtoPorId);
            await _DbContext.SaveChangesAsync();

            return true;
        }
    }
}