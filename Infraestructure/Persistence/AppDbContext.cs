using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<Tickets> Tickets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-BJLSUR0;Database=Cine2023 ;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funciones>(entity =>
            {
                entity.ToTable("Funciones");
                entity.HasKey(f => f.FuncionId);
                entity.Property(f => f.FuncionId).ValueGeneratedOnAdd();

                entity.Property(f => f.Fecha).IsRequired();
                entity.Property(f => f.Horario).IsRequired();

                entity.HasOne<Peliculas>(p => p.Pelicula)
                      .WithMany(p => p.Funciones)
                      .HasForeignKey(p => p.PeliculaId).IsRequired();
            });

            modelBuilder.Entity<Funciones>(entity =>
            {
                entity.HasOne<Salas>(s => s.Sala)
                      .WithMany(s => s.Funciones)
                      .HasForeignKey(s => s.SalaId);
            });

            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.ToTable("Peliculas");
                entity.HasKey(p => p.PeliculaId);
                entity.Property(p => p.PeliculaId).ValueGeneratedOnAdd();
                entity.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Sinopsis).HasMaxLength(255).IsRequired();
                entity.Property(p => p.Poster).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Trailer).HasMaxLength(100).IsRequired();

                entity.HasOne<Generos>(g => g.genero)
                      .WithMany(g => g.Peliculas)
                      .HasForeignKey(p => p.Genero).IsRequired();

            });

            modelBuilder.Entity<Generos>(entity =>
            {
                entity.ToTable("Generos");
                entity.HasKey(g => g.GeneroId);
                entity.Property(g => g.GeneroId).ValueGeneratedOnAdd();
                entity.Property(g => g.Nombre).HasMaxLength(50).IsRequired();

            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(t => t.TicketId);
                entity.Property(t => t.TicketId).ValueGeneratedOnAdd();

                entity.HasOne<Funciones>(f => f.funcion)
                      .WithMany(t => t.tickets)
                      .HasForeignKey(t => t.FuncionId);
                entity.Property(t => t.FuncionId).IsRequired();

                entity.Property(t => t.Usuario).HasMaxLength(50).IsRequired(); ;
            });

            modelBuilder.Entity<Salas>(entity =>
            {
                entity.ToTable("Salas");
                entity.HasKey(s => s.SalaId);
                entity.Property(s => s.SalaId).ValueGeneratedOnAdd();

                entity.Property(s => s.Nombre).HasMaxLength(50).IsRequired();

            });




            modelBuilder.Entity<Generos>().HasData(

                new Generos
                {
                    GeneroId = 1,
                    Nombre = "Acción"

                },

                new Generos
                {
                    GeneroId = 2,
                    Nombre = "Aventuras"

                },

                new Generos
                {
                    GeneroId = 3,
                    Nombre = "Ciencia Ficción"

                },

                new Generos
                {
                    GeneroId = 4,
                    Nombre = "Comedia"

                },

                new Generos
                {
                    GeneroId = 5,
                    Nombre = "Documental"

                },

                new Generos
                {
                    GeneroId = 6,
                    Nombre = "Drama"

                },

                new Generos
                {
                    GeneroId = 7,
                    Nombre = "Fantasía"

                },

                new Generos
                {
                    GeneroId = 8,
                    Nombre = "Musical"

                },

                new Generos
                {
                    GeneroId = 9,
                    Nombre = "Suspense"

                },

                new Generos
                {
                    GeneroId = 10,
                    Nombre = "Terror"

                }
                );

            modelBuilder.Entity<Salas>().HasData(

                new Salas
                {
                    SalaId = 1,
                    Nombre = "Sala 1",
                    Capacidad = 5
                },

                new Salas
                {
                    SalaId = 2,
                    Nombre = "Sala 2",
                    Capacidad = 15
                },

                new Salas
                {
                    SalaId = 3,
                    Nombre = "Sala 3",
                    Capacidad = 35
                }
                );

            modelBuilder.Entity<Peliculas>().HasData(

                new Peliculas
                {
                    PeliculaId = 1,
                    Titulo = "Avatar",
                    Sinopsis = "Ambientada en el exótico planeta Pandora, donde un ex marine se une a los nativos Na’vi para defender su mundo de la invasión humana",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/kyeqWdyUXW608qlYkRqosgbbJyK.jpg",
                    Trailer = "https://www.youtube.com/watch?v=5PSNL1qE6VY",
                    Genero = 3
                },

                new Peliculas
                {
                    PeliculaId = 2,
                    Titulo = "Bohemian Rhapsody",
                    Sinopsis = "Narra la vida y la carrera del legendario cantante de Queen, Freddie Mercury, desde sus inicios hasta el histórico concierto",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/lHu1wtNaczFPGFDTrjCSzeLPTKN.jpg",
                    Trailer = "https://www.youtube.com/watch?v=mP0VHJYFOAU",
                    Genero = 5
                },

                new Peliculas
                {
                    PeliculaId = 3,
                    Titulo = "Deadpool",
                    Sinopsis = "Sigue las aventuras de un mercenario bocazas que adquiere poderes de curación tras someterse a un experimento, y busca venganza contra el hombre que arruinó su vida.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/zq8Cl3PNIDGU3iWNRoc5nEZ6pCe.jpg",
                    Trailer = "https://www.youtube.com/watch?v=0JnRdfiUMa8",
                    Genero = 4
                },

                new Peliculas
                {
                    PeliculaId = 4,
                    Titulo = "El Excorcista",
                    Sinopsis = "El aterrador caso de una niña poseída por una entidad demoníaca, y el intento de dos sacerdotes por liberarla mediante un ritual de exorcismo.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/4ucLGcXVVSVnsfkGtbLY4XAius8.jpg",
                    Trailer = "https://www.youtube.com/watch?v=Q_Ytf1qGCTM",
                    Genero = 10
                },

                new Peliculas
                {
                    PeliculaId = 5,
                    Titulo = "Forrest Gump",
                    Sinopsis = "Protagonista Tom Hanks, que cuenta la vida de un hombre con un bajo coeficiente intelectual, pero con un gran corazón, que vive extraordinarias aventuras a lo largo de la historia reciente de EEUU.",
                    Poster = "https://m.media-amazon.com/images/I/41Al9falobL._AC_UF894,1000_QL80_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=Cyh1LpxnaxI&pp=ygUUZm9ycmVzdCBndW1wIHRyYWlsZXI%3D",
                    Genero = 6
                },

                new Peliculas
                {
                    PeliculaId = 6,
                    Titulo = "Grease",
                    Sinopsis = "Un romance entre una inocente estudiante australiana y un rebelde líder de una pandilla juvenil en el contexto de la cultura pop de los años 50",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/czVhhAaSBFpakur7U8pOIDV9NUG.jpg",
                    Trailer = "https://www.youtube.com/watch?v=THd96gHV7Tg&pp=ygUNZ3JlYXNldHJhaWxlcg%3D%3D",
                    Genero = 8
                },

                new Peliculas
                {
                    PeliculaId = 7,
                    Titulo = "Harry Potter y la piedra filosofal",
                    Sinopsis = "Presenta a Harry Potter y sus amigos, que inician su educación en el colegio Hogwarts de magia y hechicería, y se enfrentan al malvado Lord Voldemort.",
                    Poster = "https://images.justwatch.com/poster/138014805/s718/harry-potter-y-la-piedra-filosofal.jpg",
                    Trailer = "https://www.youtube.com/watch?v=ZgrCZVjPg9g",
                    Genero = 7
                },

                new Peliculas
                {
                    PeliculaId = 8,
                    Titulo = "Inception ",
                    Sinopsis = "Trata sobre realizar una incepción para implantar una idea en el subconsciente de una persona. El plan se complica debido a la intervención de alguien que parece predecir cada uno de los movimientos.",
                    Poster = "https://m.media-amazon.com/images/I/61xzvfJiNkL._AC_UF894,1000_QL80_.jpg",
                    Trailer = "https://www.youtube.com/watch?v=YoHD9XEInc0&pp=ygURaW5jZXB0aW9uIHRyYWlsZXI%3D",
                    Genero = 3
                },

                new Peliculas
                {
                    PeliculaId = 9,
                    Titulo = "Jurassic Park",
                    Sinopsis = "Muestra el caos que se desata cuando un parque temático con dinosaurios clonados se convierte en una pesadilla para sus visitantes.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/oU7Oq2kFAAlGqbU4VoAE36g4hoI.jpg",
                    Trailer = "https://www.youtube.com/watch?v=dLDkNge_AhE",
                    Genero = 3
                },

                new Peliculas
                {
                    PeliculaId = 10,
                    Titulo = "Kill Bill: Volumen 1",
                    Sinopsis = "Dirigida por Quentin Tarantino, un homenaje al cine de artes marciales y cuenta la historia de una asesina profesional conocida como La Novia, que despierta de un coma y busca vengarse de sus antiguos compañeros que intentaron matarla.",
                    Poster = "https://m.media-amazon.com/images/I/81Az82YYZaS.jpg",
                    Trailer = "https://www.youtube.com/watch?v=7kSuas6mRpk",
                    Genero = 1
                },

                new Peliculas
                {
                    PeliculaId = 11,
                    Titulo = "La lista de Schindler",
                    Sinopsis = "Una película de drama e historia dirigida por Steven Spielberg, basada en la novela homónima de Thomas Keneally",
                    Poster = "https://es.web.img2.acsta.net/pictures/14/02/27/09/35/442750.jpg",
                    Trailer = "https://www.youtube.com/watch?v=BmkchuRJ82w",
                    Genero = 6
                },

                new Peliculas
                {
                    PeliculaId = 12,
                    Titulo = "Mamma Mia!",
                    Sinopsis = "cuenta la historia de una joven que invita a tres hombres a su boda en una isla griega, con la esperanza de descubrir cuál de ellos es su padre.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/zdUA4FNHbXPadzVOJiU0Rgn6cHR.jpg",
                    Trailer = "https://www.youtube.com/watch?v=8RBNHdG35WY",
                    Genero = 8
                },

                new Peliculas
                {
                    PeliculaId = 13,
                    Titulo = "Náufrago",
                    Sinopsis = "La lucha por la vida de un hombre que queda atrapado en una isla desierta tras sufrir un accidente aéreo, y su posterior regreso a la civilización",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/7lLJgKnAicAcR5UEuo8xhSMj18w.jpg",
                    Trailer = "https://www.youtube.com/watch?v=SWC9UR1tAho",
                    Genero = 6
                },

                new Peliculas
                {
                    PeliculaId = 14,
                    Titulo = "Warcraft El Origen",
                    Sinopsis = "El pacífico reino de Azeroth está a punto de entrar en guerra contra unos terribles invasores que han dejado su destruido reino para colonizar otro.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/eGi5aoxaZveqNLtE7BZJCuWwR3G.jpg",
                    Trailer = "https://www.youtube.com/watch?v=fuGRN3dYHKg",
                    Genero = 2
                },

                new Peliculas
                {
                    PeliculaId = 15,
                    Titulo = "Parasitos",
                    Sinopsis = "Dos familias de distinta clase social en Corea del Sur, y las consecuencias de su inesperada relación.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/7IiTTgloJzvGI1TAYymCfbfl3vT.jpg",
                    Trailer = "https://www.youtube.com/watch?v=cR05bEhbWAs",
                    Genero = 6
                },

                new Peliculas
                {
                    PeliculaId = 16,
                    Titulo = "Rocky",
                    Sinopsis = "Narra la historia de un boxeador aficionado que recibe la oportunidad de enfrentarse al campeón mundial de los pesos pesados, y se prepara para el combate más importante de su vida.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8kEun6U9hTddM7NEfLLCGQKU2Mp.jpg",
                    Trailer = "https://www.youtube.com/watch?v=-Hk-LYcavrw",
                    Genero = 6
                },

                new Peliculas
                {
                    PeliculaId = 17,
                    Titulo = "Se7en",
                    Sinopsis = "sigue la investigación de dos detectives que persiguen a un asesino en serie que basa sus crímenes en los siete pecados capitales.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/6yoghtyTpznpBik8EngEmJskVUO.jpg",
                    Trailer = "https://www.youtube.com/watch?v=znmZoVkCjpI",
                    Genero = 9
                },

                new Peliculas
                {
                    PeliculaId = 18,
                    Titulo = "El Fundador",
                    Sinopsis = "La historia real de cómo Ray Kroc, un vendedor de Illinois, conoció a Mac y Dick McDonald, quienes dirigían un local de hamburguesas en el sur de California en la década de 1950.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8gLIksu5ggdfBL1UbeTeonHquxl.jpg",
                    Trailer = "https://www.youtube.com/watch?v=3uIKyTjmE_U",
                    Genero = 5
                },

                new Peliculas
                {
                    PeliculaId = 19,
                    Titulo = "Un lugar tranquilo",
                    Sinopsis = "Una familia se ve obligada a vivir en silencio mientras se esconde de las criaturas que cazan mediante el sonido.",
                    Poster = "https://image.tmdb.org/t/p/w600_and_h900_bestv2/nAU74GmpUk7t5iklEp3bufwDq4n.jpg",
                    Trailer = "https://www.youtube.com/watch?v=RV8gX2bXUOk",
                    Genero = 10
                },

                new Peliculas
                {
                    PeliculaId = 20,
                    Titulo = "Taxi Driver",
                    Sinopsis = "Para sobrellevar el insomnio crónico que sufre desde su regreso de Vietnam, Travis Bickle trabaja como taxista nocturno en Nueva York.",
                    Poster = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ekstpH614fwDX8DUln1a2Opz0N8.jpg",
                    Trailer = "https://www.youtube.com/watch?v=T5IligQP7Fo",
                    Genero = 9
                }

                );
        }

    }
}
