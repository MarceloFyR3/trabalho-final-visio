using System;

namespace Trabalho.Final.Visual.Dominio.Entidades
{
    public class Agenda : Entity<int>
    {
        public Agenda()
        {

        }
        public DateTime DiaHora { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Pet Pet { get; set; }
    }
}
