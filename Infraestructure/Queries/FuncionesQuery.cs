using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Queries
{
    public class FuncionesQuery : IFuncionesQuery
    {
        private readonly AppDbContext _appDbContext;

        public FuncionesQuery(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Funciones>> GetFuncionesPorTitulo(string titulo)
        {
            return await _appDbContext.Funciones.ToListAsync();
        }
    }
}
