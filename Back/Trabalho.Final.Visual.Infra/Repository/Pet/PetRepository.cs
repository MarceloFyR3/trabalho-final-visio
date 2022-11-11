using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Infra.Context;

namespace Trabalho.Final.Visual.Infra.Repository.Pet
{
    public class PetRepository : GenericRepository<Dominio.Entidades.Pet, int>, IPetRepository
    {
        public PetRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> Update(Dominio.Entidades.Pet pet)
        {

            var @return = false;

            var entity = await Get(pet.Id);

            if (entity != null)
            {
                pet.ClienteId = entity.ClienteId;
                _dbContext.Entry(entity).CurrentValues.SetValues(pet);
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
