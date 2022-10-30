using System.Collections.Generic;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;
using Trabalho.Final.Visual.Dominio.Modelo;

namespace Trabalho.Final.Visual.Dominio.Interface.Services
{
    public interface IPetServices
    {
        Task<bool> Cadastrar(PetModelo modelo);

        Task<bool> Atualizar(PetModelo modelo);

        Task<Pet> BuscarPorId(int id);

        Task<IEnumerable<Pet>> BuscarTodos();

        Task<bool> MudarStatsu(int id, bool status);
    }
}
