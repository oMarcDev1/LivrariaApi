using LivrariaApi.Data;
using LivrariaApi.DTO.Autor;
using LivrariaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApi.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int IdAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == IdAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int IdLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
               var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);   
               if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado";
                return resposta;
            }catch (Exception ex)
            {
                resposta.Mensagem=ex.Message;
                resposta.Status = false;
                return resposta;
                
            }
        }

        public async Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO )
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDTO.Nome,
                    Sobrenome = autorCriacaoDTO.Sobrenome
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Autor criado com sucesso";
                return resposta;


            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDTO.Id);
                if (autor == null)
                {
                  
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }
                autor.Nome = autorEdicaoDTO.Nome;
                autor.Sobrenome = autorEdicaoDTO.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Autor editado com sucesso";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> ExcluirAutor(int IdAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == IdAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Autor excluído com sucesso";
                return resposta;
            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Autores listados com sucesso";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
