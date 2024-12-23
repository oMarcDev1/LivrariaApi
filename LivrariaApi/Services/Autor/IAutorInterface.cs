using LivrariaApi.DTO.Autor;
using LivrariaApi.Models;

namespace LivrariaApi.Services.Autor
{
    public interface IAutorInterface
    {
       Task<ResponseModel<List<AutorModel>>> ListarAutores();
       Task<ResponseModel<AutorModel>> BuscarAutorPorId(int IdAutor);
       Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int IdLivro);
       Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO);
        Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO);
        Task<ResponseModel<AutorModel>> ExcluirAutor(int IdAutor);

    }
}
