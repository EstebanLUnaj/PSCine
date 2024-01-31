using Aplication.Interfaces;
using Domain.Entities;

namespace Aplication.UseCase.SFunciones
{
    public class FuncionesServices : IFuncionesService
    {
       
        private readonly IFuncionesCommand _funcionesCommand;
      

        public FuncionesServices(IFuncionesCommand funcionesCommand)
        {
            _funcionesCommand = funcionesCommand;
        }

        public async Task<Funciones> createFuncion(int pelid, int salid, DateTime fec, TimeSpan hor)
        {
            var funcion = new Funciones
            {
                PeliculaId = pelid,
                SalaId = salid,
                Fecha = fec,
                Horario = hor
            };
            await _funcionesCommand.insertFunciones(funcion);
            Console.WriteLine("Funcion creada con exito");
            return funcion;
        }

    }
}
