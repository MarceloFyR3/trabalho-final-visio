using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Infra.Context;

namespace Trabalho.Final.Visual.Infra.Repository.Cliente
{
    public class ClienteRepository : GenericRepository<Dominio.Entidades.Cliente, int>, IClienteRepository
    {
        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> Update(Dominio.Entidades.Cliente cliente)
        {

            var @return = false;

            var cli = await Get(cliente.Id);

            if (cli != null)
            {
                _dbContext.Entry(cli).CurrentValues.SetValues(cliente);
                await _dbContext.SaveChangesAsync();

                @return = true;
            }

            return @return;
        }

        public async Task<bool> ChangeStatus(int id, bool status)
        {

            var @return = false;

            var cliente = await Get(id);

            if (cliente != null)
            {
                cliente.Ativo = status;
                await _dbContext.SaveChangesAsync();

                @return = true;
            }

            return @return;
        }
    }
}
