using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Commands
{
    public class FuncionesCommand : IFuncionesCommand
    {
        private readonly AppDbContext _appDbContext;

        public FuncionesCommand(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Funciones>> GetFuncionesPorDia(DateTime dia)
        {
            List<Funciones> funcionesPorDia = null;
            Task<List<Funciones>> fmd = _appDbContext.Funciones.Where(f => f.Fecha == dia).ToListAsync();
            List<Funciones> listFunciones = await fmd;
            if (listFunciones != null && listFunciones.Count > 0)
            {
                funcionesPorDia = listFunciones;
            }
            return funcionesPorDia;
        }

        public async Task<List<Funciones>> GetFuncionesPorPelicula(int idp)
        {
            List<Funciones> funcionesPorPeli = null;

            Task<List<Funciones>> fmp = _appDbContext.Funciones.Where(f => f.PeliculaId == idp).ToListAsync();
            List<Funciones> listFunciones = await fmp;
            if (listFunciones != null && listFunciones.Count > 0)
            {
                funcionesPorPeli = listFunciones;
            }
            return funcionesPorPeli;
        }

        public async Task<List<Funciones>> GetFuncionesPorPeliculayDia(DateTime dia, int idp)
        {
            List<Funciones> funcionesPeliDia = null;

            Task<List<Funciones>> fpd = _appDbContext.Funciones.Where(f => f.Fecha == dia && f.PeliculaId == idp).ToListAsync();
            List<Funciones> listFunciones = await fpd;
            if (listFunciones != null && listFunciones.Count > 0)
            {
                funcionesPeliDia = listFunciones;
            }
            return funcionesPeliDia;
        }


        public async Task<Funciones> insertFunciones(Funciones funciones)
        {
            await _appDbContext.AddAsync(funciones);
            await _appDbContext.SaveChangesAsync();
            return funciones;
        }
    }
}
