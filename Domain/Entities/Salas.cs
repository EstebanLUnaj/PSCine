namespace Domain.Entities
{
    public class Salas
    {
        public int SalaId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public IList<Funciones> Funciones { get; set; } = null!;
    }
}
