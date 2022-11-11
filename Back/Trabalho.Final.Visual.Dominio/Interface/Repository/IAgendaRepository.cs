using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;

namespace Trabalho.Final.Visual.Dominio.Interface.Repository
{
    public interface IAgendaRepository : IGenericRepository<Agenda, int>
    {
        Task<bool> Update(Agenda agenda);
    }
}
