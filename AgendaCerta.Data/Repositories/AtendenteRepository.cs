using AgendaCerta.Data.Context;
using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaCerta.Data.Repositories
{
    public class AtendenteRepository : BaseRepository<Atendente>, IAtendenteRepository
    {
        public AtendenteRepository(AgendaCertaContext context) : base(context)
        {
        }

        public async Task<Atendente?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Atendente?> GetByCPFAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.CPF == cpf);
        }

        public async Task<IEnumerable<Atendente?>> GetByEspecialidadeAsync(string especialidade)
        {
            return await _dbSet.Where(a => a.Especialidade == especialidade).ToListAsync();
        }
    }
}