using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IFuncionesCommand
    {
        public Task<Funciones> insertFunciones(Funciones funciones);
        public Task<List<Funciones>> GetFuncionesPorDia(DateTime dia);

        public Task<List<Funciones>> GetFuncionesPorPelicula(int idp);
        public Task<List<Funciones>> GetFuncionesPorPeliculayDia(DateTime dia, int idp);


    }
}
