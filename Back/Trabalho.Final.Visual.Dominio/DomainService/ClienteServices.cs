using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Dominio.Interface.Services;
using Trabalho.Final.Visual.Dominio.Modelo;

namespace Trabalho.Final.Visual.Dominio.DomainService
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _petRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _petRepository = clienteRepository;
        }

        public async Task<bool> Atualizar(ClienteModelo modelo)
        {
            var entity = new Cliente { Id = modelo.Id, Nome = modelo.Nome, Email = modelo.Email };

            var @return = await _petRepository.Update(entity);

            return @return;
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            var @return = await _petRepository.Get(id);
            return @return;
        }

        public async Task<IEnumerable<Cliente>> BuscarTodos()
        {
            var @return = await _petRepository.FindAll(predicate: p => p.Ativo);
            return @return;
        }

        public async Task<bool> Cadastrar(ClienteModelo modelo)
        {
            var entity = new Cliente
            {
                Nome = modelo.Nome,
                Email = modelo.Email,
                Ativo = true
            };

            var item = await _petRepository.CreateItem(entity);

            if (item != null)
                return true;

            return false;
        }

        public async Task<bool> MudarStatsu(int id, bool status)
        {
            return await _petRepository.ChangeStatus(id, status);
        }
    }
}
