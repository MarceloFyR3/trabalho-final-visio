using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;

namespace Trabalho.Final.Visual.Dominio.Interface.Repository
{
    public interface IPetRepository : IGenericRepository<Pet, int>
    {
        Task<bool> Update(Pet pet);
        Task<bool> ChangeStatus(int id, bool status);
    }
}
