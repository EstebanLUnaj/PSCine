using Domain.Entities;

namespace PSCine
{
    public class ListaDePeliculas
    {
        public void PeliculasList(List<Peliculas> peliculas)
        {
            foreach (var p in peliculas)
            {
                Console.WriteLine("ID DE PELICULA: " + p.PeliculaId + " TITULO DE PELICULA: " + p.Titulo);
            }
        }
    }
}
