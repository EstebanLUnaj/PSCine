﻿
namespace Domain.Entities
{
    public class Tickets
    {
        public Guid TicketId { get; set; }
        public int FuncionId { get; set; }
        public string Usuario { get; set; }
        public Funciones funcion { get; set; }
    }
}
