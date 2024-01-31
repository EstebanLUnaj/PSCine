using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IFuncionesQuery
    {
        
        Task<List<Funciones>> GetFuncionesPorTitulo(string titulo);
    }
}
