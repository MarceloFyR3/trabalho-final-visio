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
        public int PetId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
