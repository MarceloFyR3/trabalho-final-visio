using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Entidades;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Dominio.Interface.Services;
using Trabalho.Final.Visual.Dominio.Modelo;

namespace Trabalho.Final.Visual.Dominio.DomainService
{
    public class PetServices : IPetServices
    {
        private readonly IPetRepository _petRepository;

        public PetServices(IPetRepository clienteRepository)
        {
            _petRepository = clienteRepository;
        }

        public async Task<bool> Atualizar(PetModelo modelo)
        {
            var entity = new Pet { Id = modelo.Id, Nome = modelo.Nome, Idade = modelo.Idade, Porte = modelo.Porte, Ativo = modelo.Ativo };

            var @return = await _petRepository.Update(entity);

            return @return;
        }

        public async Task<Pet> BuscarPorId(int id)
        {
            var @return = await _petRepository.Get(id);
            return @return;
        }

        public async Task<IEnumerable<Pet>> BuscarTodos()
        {
            var @return = await _petRepository.FindAll(predicate: p => p.Ativo);
            return @return;
        }

        public async Task<bool> Cadastrar(PetModelo modelo)
        {
            var entity = new Pet
            {
                Nome = modelo.Nome,
                Porte = modelo.Porte,
                Idade = modelo.Idade,
                Ativo = modelo.Ativo
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
