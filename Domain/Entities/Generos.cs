namespace Domain.Entities
{
    public class Generos
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public IList<Peliculas> Peliculas { get; set; } = null!;
    }
}
