using AgendaCerta.Data.Context;
using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaCerta.Data.Repositories
{
    public class ClienteRepository(AgendaCertaContext context) : BaseRepository<Cliente>(context), IClienteRepository
    {
        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Cliente?> GetByCPFAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

        public override async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Agendamentos)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}