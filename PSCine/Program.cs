// See https://aka.ms/new-console-template for more information
using Aplication.UseCase.SFunciones;
using Aplication.UseCase.SPeliculas;
using Domain.Entities;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Queries;
using PSCine;

AppDbContext appDbContext = new AppDbContext();
PeliculasQuery peliculasQuery = new PeliculasQuery(appDbContext);
PeliculasServices peliculasServices = new PeliculasServices(peliculasQuery);

FuncionesCommand funcionesCommand = new FuncionesCommand(appDbContext);
FuncionesServices funcionesServices = new FuncionesServices(funcionesCommand);

bool menu = true;

while (menu)
{
    Console.Clear();
    Console.WriteLine("Seleccione una opcion");
    Console.WriteLine("1- Listar Funcion por Pelicula");
    Console.WriteLine("2-Listar Funcion por Fecha");
    Console.WriteLine("3-Listar funcion por Pelicula y Fecha");
    Console.WriteLine("4-Cargar una nueva funcion");
    Console.WriteLine("5-Salir ");
    switch (Console.ReadLine())
    {
        case "1":
            try
            {
                Console.Clear();
                Console.WriteLine("Enliste la funcion en base a la Pelicula.");
                ListaDePeliculas listaDePeliculas = new ListaDePeliculas();
                listaDePeliculas.PeliculasList(peliculasQuery.GetListPeliculas().Result);
                Console.WriteLine("Ingrese el id de la pelicula: ");
                int idp1 = int.Parse(Console.ReadLine());
                if (peliculasQuery.GetPeliculasById(idp1).Result == null)
                {
                    Console.WriteLine("No se encontro pelicula");
                }
                else
                {
                    Peliculas pel = peliculasQuery.GetPeliculasById(idp1).Result;
                    Console.WriteLine("TITULO : " + pel.Titulo);
                    Console.WriteLine("SINOPSIS: " + pel.Sinopsis);
                    Console.WriteLine("POSTER: " + pel.Poster);
                    Console.WriteLine("TRAILER: " + pel.Trailer);
                    Console.WriteLine("GENERO : " + pel.Genero);

                    var flist1 = await funcionesCommand.GetFuncionesPorPelicula(pel.PeliculaId);

                    foreach (Funciones func1 in flist1)
                    {
                        Console.WriteLine("ID DE LA FUNCION: " + func1.FuncionId + " ID DE LA SALA: " + func1.SalaId + " FECHA DE LA FUNCION: " + func1.Fecha + " HORARIO DE LA FUNCION: " + func1.Horario);
                    }


                }
                Console.ReadKey();
            }
            catch (Exception e)
            {

                Console.WriteLine("A ocurrido un  error "+ e.Message );
                Console.ReadKey();
            }
            break;
            
        case "2":
            try
            {
                Console.Clear();
                Console.WriteLine("Enliste las funciones en base al dia de la funcion");
                Console.WriteLine("Ingrese horario de funcion: Ingrese el dia ");
                int fd2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese horario de funcion: Ingrese el mes ");
                int fm2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese horario de funcion: Ingrese el año ");
                int fa2 = int.Parse(Console.ReadLine());
                DateTime ffec2 = new DateTime(fa2, fm2, fd2);

                var flist2 = await funcionesCommand.GetFuncionesPorDia(ffec2);

                foreach (Funciones funciones in flist2)
                {
                    Console.WriteLine("ID:" + funciones.FuncionId + " ID DE PELICULA: " + funciones.PeliculaId + " ID DE LA SALA: " + funciones.SalaId + " FECHA DE LA FUNCION: " + funciones.Fecha + " HORARIO DE LA FUNCION: " + funciones.Horario);
                }
                Console.ReadKey();
                
            }
            catch (Exception e)
            {

                Console.WriteLine("A ocurrido un  error " + e.Message);
                Console.ReadKey();
            }
            break;

        case "3":
            try
            {
                Console.Clear();
                Console.WriteLine("Enliste las funciones en base a la pelicula y el dia de la funcion");
                ListaDePeliculas ldp6 = new ListaDePeliculas();
                ldp6.PeliculasList(peliculasQuery.GetListPeliculas().Result);
                Console.WriteLine("Ingrese el ID de la pelicula:");
                int fp3 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la fecha de la funcion: Ingrese el dia");

                int fd3 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese horario de funcion: Ingrese el mes ");
                int fm3 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese horario de funcion: Ingrese el año ");
                int fa3 = int.Parse(Console.ReadLine());
                DateTime ffec6 = new DateTime(fa3, fm3, fd3);



                if (peliculasQuery.GetPeliculasById(fp3).Result == null)
                {
                    Console.WriteLine("No se encontro pelicula");
                }
                else
                {
                    Peliculas pel3 = peliculasQuery.GetPeliculasById(fp3).Result;
                    Console.WriteLine("TITULO : " + pel3.Titulo);
                    Console.WriteLine("SINOPSIS: " + pel3.Sinopsis);
                    Console.WriteLine("POSTER: " + pel3.Poster);
                    Console.WriteLine("TRAILER: " + pel3.Trailer);
                    Console.WriteLine("GENERO : " + pel3.Genero);

                    var flist3 = await funcionesCommand.GetFuncionesPorPeliculayDia(ffec6, pel3.PeliculaId);

                    foreach (Funciones f3 in flist3)
                    {
                        Console.WriteLine("ID DE LA FUNCION: " + f3.FuncionId + " ID DE LA SALA: " + f3.SalaId + " FECHA DE LA FUNCION: " + f3.Fecha + " HORARIO DE LA FUNCION: " + f3.Horario);
                    }


                }

                Console.ReadKey();
            }
            catch (Exception e)
            {

                Console.WriteLine("A ocurrido un  error " + e.Message);
                Console.ReadKey();
            }
           
            break;
        case "4":
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese Id de Pelicula para la Funcion");
                int pelid = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese ID de Sala para la Funcion");
                int salid = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese fecha de funcion: ingrese año AAAA:");
                int afec = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese fecha de funcion: ingrese mes MM:");
                int mfec = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese fecha de funcion: ingrese dia DD:");
                int dfec = int.Parse(Console.ReadLine());
                DateTime fec = new DateTime(afec, mfec, dfec);
                Console.WriteLine("Ingrese horario de funcion: Ingrese las horas");
                int hhor = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese horario de funcion: Ingrese los minutos");
                int mhor = int.Parse(Console.ReadLine());
                TimeSpan hor = new TimeSpan(hhor, mhor, 0);
                funcionesServices.createFuncion(pelid, salid, fec, hor);
                Console.ReadKey();
            }
            catch (Exception e)
            {

                Console.WriteLine("A ocurrido un  error " + e.Message);
                Console.ReadKey();
            }
            
            break;

        case "5":
            menu = false; break;
        default: break;
    }
}

