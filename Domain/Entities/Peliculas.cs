namespace Domain.Entities
{
    public class Peliculas
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public int Genero { get; set; }
        public Generos genero { get; set; }
        public IList<Funciones> Funciones { get; set; } = null!;

    }
}
