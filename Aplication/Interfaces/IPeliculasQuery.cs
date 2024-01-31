using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IPeliculasQuery
    {
        Task<List<Peliculas>> GetListPeliculas();
        Task<Peliculas> GetPeliculasById(int id);
    }
}
