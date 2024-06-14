using MaisProdutos.Models;
using MaisProdutos.Models.Dtos;
using MaisProdutos.Repositorios;
using MaisProdutos.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaisProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio, ICategoriaRepositorio categoriaRepositorio) 
        {
            _produtoRepositorio = produtoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoDto produtoDto)
        {
            ProdutoModel novoProduto = new ProdutoModel
            {
                Nome = produtoDto.Nome,
                Preco = produtoDto.Preco,
                Quantidade = produtoDto.Quantidade,
                Categoria = await _categoriaRepositorio.BuscarPorId(produtoDto.CategoriaId),
                Descricao = produtoDto.Descricao,
                Status = produtoDto.Status
            };
            ProdutoModel produto = await _produtoRepositorio.Adicionar(novoProduto);

            return Ok(produto); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoDto produtoDto, int id)
        {
            ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoDto, id);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Deletar(int id)
        {
            bool deletado = await _produtoRepositorio.Deletar(id);

            return Ok(deletado);
        }
    }
}  
