using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;

namespace Trabalho.Final.Visual.Dominio.Interface.Repository
{
    public interface IClienteRepository : IGenericRepository<Cliente, int>
    {
        Task<bool> Update(Cliente cliente);
        Task<bool> ChangeStatus(int id, bool status);
    }
}
