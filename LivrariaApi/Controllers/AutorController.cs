using LivrariaApi.DTO.Autor;
using LivrariaApi.Models;
using LivrariaApi.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }
        [HttpGet("BuscarAutorPorId/{IdAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int IdAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(IdAutor);
            return Ok(autor);
        }
        [HttpGet("BuscarAutorPorIdLivro/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int IdLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(IdLivro);
            return Ok(autor);
        }
        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDTO);
            return Ok(autores);
        }
        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicaoDTO);
            return Ok(autores);
        }
        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int IdAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(IdAutor);
            return Ok(autores);
        }
    }
}
