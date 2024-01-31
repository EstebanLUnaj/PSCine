using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_Genero",
                        column: x => x.Genero,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Aventuras" },
                    { 3, "Ciencia Ficción" },
                    { 4, "Comedia" },
                    { 5, "Documental" },
                    { 6, "Drama" },
                    { 7, "Fantasía" },
                    { 8, "Musical" },
                    { 9, "Suspense" },
                    { 10, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 5, "Sala 1" },
                    { 2, 15, "Sala 2" },
                    { 3, 35, "Sala 3" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Genero", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, 3, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/kyeqWdyUXW608qlYkRqosgbbJyK.jpg", "Ambientada en el exótico planeta Pandora, donde un ex marine se une a los nativos Na’vi para defender su mundo de la invasión humana", "Avatar", "https://www.youtube.com/watch?v=5PSNL1qE6VY" },
                    { 2, 5, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/lHu1wtNaczFPGFDTrjCSzeLPTKN.jpg", "Narra la vida y la carrera del legendario cantante de Queen, Freddie Mercury, desde sus inicios hasta el histórico concierto", "Bohemian Rhapsody", "https://www.youtube.com/watch?v=mP0VHJYFOAU" },
                    { 3, 4, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/zq8Cl3PNIDGU3iWNRoc5nEZ6pCe.jpg", "Sigue las aventuras de un mercenario bocazas que adquiere poderes de curación tras someterse a un experimento, y busca venganza contra el hombre que arruinó su vida.", "Deadpool", "https://www.youtube.com/watch?v=0JnRdfiUMa8" },
                    { 4, 10, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/4ucLGcXVVSVnsfkGtbLY4XAius8.jpg", "El aterrador caso de una niña poseída por una entidad demoníaca, y el intento de dos sacerdotes por liberarla mediante un ritual de exorcismo.", "El Excorcista", "https://www.youtube.com/watch?v=Q_Ytf1qGCTM" },
                    { 5, 6, "https://m.media-amazon.com/images/I/41Al9falobL._AC_UF894,1000_QL80_.jpg", "Protagonista Tom Hanks, que cuenta la vida de un hombre con un bajo coeficiente intelectual, pero con un gran corazón, que vive extraordinarias aventuras a lo largo de la historia reciente de EEUU.", "Forrest Gump", "https://www.youtube.com/watch?v=Cyh1LpxnaxI&pp=ygUUZm9ycmVzdCBndW1wIHRyYWlsZXI%3D" },
                    { 6, 8, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/czVhhAaSBFpakur7U8pOIDV9NUG.jpg", "Un romance entre una inocente estudiante australiana y un rebelde líder de una pandilla juvenil en el contexto de la cultura pop de los años 50", "Grease", "https://www.youtube.com/watch?v=THd96gHV7Tg&pp=ygUNZ3JlYXNldHJhaWxlcg%3D%3D" },
                    { 7, 7, "https://images.justwatch.com/poster/138014805/s718/harry-potter-y-la-piedra-filosofal.jpg", "Presenta a Harry Potter y sus amigos, que inician su educación en el colegio Hogwarts de magia y hechicería, y se enfrentan al malvado Lord Voldemort.", "Harry Potter y la piedra filosofal", "https://www.youtube.com/watch?v=ZgrCZVjPg9g" },
                    { 8, 3, "https://m.media-amazon.com/images/I/61xzvfJiNkL._AC_UF894,1000_QL80_.jpg", "Trata sobre realizar una incepción para implantar una idea en el subconsciente de una persona. El plan se complica debido a la intervención de alguien que parece predecir cada uno de los movimientos.", "Inception ", "https://www.youtube.com/watch?v=YoHD9XEInc0&pp=ygURaW5jZXB0aW9uIHRyYWlsZXI%3D" },
                    { 9, 3, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/oU7Oq2kFAAlGqbU4VoAE36g4hoI.jpg", "Muestra el caos que se desata cuando un parque temático con dinosaurios clonados se convierte en una pesadilla para sus visitantes.", "Jurassic Park", "https://www.youtube.com/watch?v=dLDkNge_AhE" },
                    { 10, 1, "https://m.media-amazon.com/images/I/81Az82YYZaS.jpg", "Dirigida por Quentin Tarantino, un homenaje al cine de artes marciales y cuenta la historia de una asesina profesional conocida como La Novia, que despierta de un coma y busca vengarse de sus antiguos compañeros que intentaron matarla.", "Kill Bill: Volumen 1", "https://www.youtube.com/watch?v=7kSuas6mRpk" },
                    { 11, 6, "https://es.web.img2.acsta.net/pictures/14/02/27/09/35/442750.jpg", "Una película de drama e historia dirigida por Steven Spielberg, basada en la novela homónima de Thomas Keneally", "La lista de Schindler", "https://www.youtube.com/watch?v=BmkchuRJ82w" },
                    { 12, 8, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/zdUA4FNHbXPadzVOJiU0Rgn6cHR.jpg", "cuenta la historia de una joven que invita a tres hombres a su boda en una isla griega, con la esperanza de descubrir cuál de ellos es su padre.", "Mamma Mia!", "https://www.youtube.com/watch?v=8RBNHdG35WY" },
                    { 13, 6, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/7lLJgKnAicAcR5UEuo8xhSMj18w.jpg", "La lucha por la vida de un hombre que queda atrapado en una isla desierta tras sufrir un accidente aéreo, y su posterior regreso a la civilización", "Náufrago", "https://www.youtube.com/watch?v=SWC9UR1tAho" },
                    { 14, 2, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/eGi5aoxaZveqNLtE7BZJCuWwR3G.jpg", "El pacífico reino de Azeroth está a punto de entrar en guerra contra unos terribles invasores que han dejado su destruido reino para colonizar otro.", "Warcraft El Origen", "https://www.youtube.com/watch?v=fuGRN3dYHKg" },
                    { 15, 6, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/7IiTTgloJzvGI1TAYymCfbfl3vT.jpg", "Dos familias de distinta clase social en Corea del Sur, y las consecuencias de su inesperada relación.", "Parasitos", "https://www.youtube.com/watch?v=cR05bEhbWAs" },
                    { 16, 6, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8kEun6U9hTddM7NEfLLCGQKU2Mp.jpg", "Narra la historia de un boxeador aficionado que recibe la oportunidad de enfrentarse al campeón mundial de los pesos pesados, y se prepara para el combate más importante de su vida.", "Rocky", "https://www.youtube.com/watch?v=-Hk-LYcavrw" },
                    { 17, 9, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/6yoghtyTpznpBik8EngEmJskVUO.jpg", "sigue la investigación de dos detectives que persiguen a un asesino en serie que basa sus crímenes en los siete pecados capitales.", "Se7en", "https://www.youtube.com/watch?v=znmZoVkCjpI" },
                    { 18, 5, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8gLIksu5ggdfBL1UbeTeonHquxl.jpg", "La historia real de cómo Ray Kroc, un vendedor de Illinois, conoció a Mac y Dick McDonald, quienes dirigían un local de hamburguesas en el sur de California en la década de 1950.", "El Fundador", "https://www.youtube.com/watch?v=3uIKyTjmE_U" },
                    { 19, 10, "https://image.tmdb.org/t/p/w600_and_h900_bestv2/nAU74GmpUk7t5iklEp3bufwDq4n.jpg", "Una familia se ve obligada a vivir en silencio mientras se esconde de las criaturas que cazan mediante el sonido.", "Un lugar tranquilo", "https://www.youtube.com/watch?v=RV8gX2bXUOk" },
                    { 20, 9, "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ekstpH614fwDX8DUln1a2Opz0N8.jpg", "Para sobrellevar el insomnio crónico que sufre desde su regreso de Vietnam, Travis Bickle trabaja como taxista nocturno en Nueva York.", "Taxi Driver", "https://www.youtube.com/watch?v=T5IligQP7Fo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Genero",
                table: "Peliculas",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
