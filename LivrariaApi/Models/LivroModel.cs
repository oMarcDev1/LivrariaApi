namespace LivrariaApi.Models
{
    public class LivroModel
    {
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public int Id { get; set; }
        public AutorModel Autor { get; set; }
    }
}
