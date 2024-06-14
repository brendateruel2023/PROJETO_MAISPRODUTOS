using MaisProdutos.Models;
using MaisProdutos.Repositorios;
using MaisProdutos.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MaisProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarCategorias()
        {
            IEnumerable<CategoriaModel> categorias = await _categoriaRepositorio.BuscarCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> BuscarPorId(int id)
        {
            CategoriaModel categoria = await _categoriaRepositorio.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaModel>> Cadastrar([FromBody] CategoriaModel categoriaModel)
        {
            CategoriaModel categoria = await _categoriaRepositorio.Adicionar(categoriaModel);

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaModel>> Atualizar([FromBody] CategoriaModel categoriaModel, int id)
        {
            categoriaModel.Id = id;
            CategoriaModel categoria = await _categoriaRepositorio.Atualizar(categoriaModel, id);

            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaModel>> Deletar(int id)
        {
            bool deletado = await _categoriaRepositorio.Deletar(id);

            return Ok(deletado);
        }
    }
}

