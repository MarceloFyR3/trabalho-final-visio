using Microsoft.EntityFrameworkCore;
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

        public async Task<Agenda> BuscarPorId(int id)
        {
            var @return = await _agendaRepository.Find(predicate: p=> p.Id.Equals(id), include: i => i.Include(p => p.Cliente).Include(p => p.Pet));
            return @return;
        }

        public async Task<IEnumerable<Agenda>> BuscarTodos()
        {
            var @return = await _agendaRepository.FindAll(predicate: p => p.DiaHora > DateTime.Now);
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
