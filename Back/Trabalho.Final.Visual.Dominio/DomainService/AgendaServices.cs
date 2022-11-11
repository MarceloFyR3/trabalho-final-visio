using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Dominio.Interface.Services;
using Trabalho.Final.Visual.Dominio.Modelo;

namespace Trabalho.Final.Visual.Dominio.DomainService
{
    public class AgendaServices : IAgendaServices
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaServices(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<bool> Atualizar(AgendaModelo modelo)
        {
            var entity = new Agenda { Id = modelo.Id, DiaHora = modelo.DiaHora, PetId = modelo.PetId };

            var @return = await _agendaRepository.Update(entity);

            return @return;
        }

        public async Task<Agenda> BuscarPorId(int id)
        {
            var @return = await _agendaRepository.Get(id);
            return @return;
        }

        public async Task<IEnumerable<Agenda>> BuscarTodos()
        {
            var @return = await _agendaRepository.GetAll();
            return @return;
        }

        public async Task<bool> Cadastrar(AgendaModelo modelo)
        {
            var entity = new Agenda
            {
                DiaHora = modelo.DiaHora,
                ClienteId = modelo.ClienteId,
                PetId = modelo.PetId
            };

            var item = await _agendaRepository.CreateItem(entity);

            if (item != null)
                return true;

            return false;
        }

        public async Task<bool> Deletar(int id)
        {
            await _agendaRepository.Delete(id);
            return true;
        }

    }
}
