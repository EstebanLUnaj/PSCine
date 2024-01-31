using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Queries
{
    public class PeliculasQuery : IPeliculasQuery
    {
        private readonly AppDbContext _appDbContext;

        public PeliculasQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Peliculas>> GetListPeliculas()
        {
            return await _appDbContext.Peliculas.ToListAsync();
        }
        public async Task<Peliculas> GetPeliculasById(int id)
        {
            var pelicula = await _appDbContext.Peliculas.FindAsync(id);
            return pelicula;
        }
    }
}
