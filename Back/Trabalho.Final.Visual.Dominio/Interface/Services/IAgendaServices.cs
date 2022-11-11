using System.Collections.Generic;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;
using Trabalho.Final.Visual.Dominio.Modelo;

namespace Trabalho.Final.Visual.Dominio.Interface.Services
{
    public interface IAgendaServices
    {
        Task<bool> Cadastrar(AgendaModelo modelo);

        Task<Agenda> BuscarPorId(int id);

        Task<IEnumerable<Agenda>> BuscarTodos();

        Task<bool> Deletar(int id);
    }
}
