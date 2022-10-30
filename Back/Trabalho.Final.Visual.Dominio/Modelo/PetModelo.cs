using Trabalho.Final.Visual.Dominio.Enum;

namespace Trabalho.Final.Visual.Dominio.Modelo
{
    public class PetModelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
        public PorteEnum Porte { get; set; }
    }
}
