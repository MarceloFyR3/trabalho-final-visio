using System.Collections.Generic;
using Trabalho.Final.Visual.Dominio.Enum;

namespace Trabalho.Final.Visual.Dominio.Entidades
{
    public class Pet : Entity<int>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
        public PorteEnum Porte { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}
