using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IFuncionesService
    {      
        Task<Funciones> createFuncion(int pelid, int salid, DateTime fec, TimeSpan hor);
    }
}
