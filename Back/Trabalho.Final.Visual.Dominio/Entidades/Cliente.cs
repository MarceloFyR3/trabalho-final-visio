using System.Collections.Generic;

namespace Trabalho.Final.Visual.Dominio.Entidades
{
    public class Cliente : Entity<int>
    {
        public Cliente()
        {

        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Agenda> Agendas { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }

    }
}
