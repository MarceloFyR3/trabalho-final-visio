using System;

namespace Trabalho.Final.Visual.Dominio.Modelo
{
    public class AgendaModelo
    {
        public int Id { get; set; }
        public DateTime DiaHora { get; set; }
        public int ClienteId { get; set; }
        public int PetId { get; set; }
    }
}