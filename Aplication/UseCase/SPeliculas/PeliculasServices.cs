using Aplication.Interfaces;
using Domain.Entities;

namespace Aplication.UseCase.SPeliculas
{
    public class PeliculasServices : IPeliculasService
    {
        private readonly IPeliculasQuery _peliculasQuery;
        public PeliculasServices(IPeliculasQuery peliculasQuery)
        {
            _peliculasQuery = peliculasQuery;
        }
        
    }
}
