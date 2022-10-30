using System.Collections.Generic;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;
using Trabalho.Final.Visual.Dominio.Modelo;

namespace Trabalho.Final.Visual.Dominio.Interface.Services
{
    public interface IClienteServices
    {
        Task<bool> Cadastrar(ClienteModelo modelo);

        Task<bool> Atualizar(ClienteModelo modelo);

        Task<Cliente> BuscarPorId(int id);

        Task<IEnumerable<Cliente>> BuscarTodos();

        Task<bool> MudarStatsu(int id, bool status);
    }
}
