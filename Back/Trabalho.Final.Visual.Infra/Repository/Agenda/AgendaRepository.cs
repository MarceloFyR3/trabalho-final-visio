using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Infra.Context;

namespace Trabalho.Final.Visual.Infra.Repository.Agenda
{
    public class AgendaRepository: GenericRepository<Dominio.Entidades.Agenda, int>, IAgendaRepository
    {
        public AgendaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> Update(Dominio.Entidades.Agenda agenda)
        {
            var @return = false;

            var entity = await Get(agenda.Id);

            if (entity != null)
            {
                entity.DiaHora = agenda.DiaHora;
                entity.ClienteId = agenda.ClienteId;
                entity.PetId = agenda.PetId;

                await _dbContext.SaveChangesAsync();

                @return = true;
            }

            return @return;
        }
    }
}