using AgendaCerta.Data.Context;
using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaCerta.Data.Repositories
{
    public class AgendamentoRepository(AgendaCertaContext context) : BaseRepository<Agendamento>(context), IAgendamentoRepository
    {
        public override async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Where(a => a.Id == id)
                .Include(a => a.Cliente)
                .Include(a => a.Atendente).FirstOrDefaultAsync();
        }
        public override async Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            return await _dbSet
                .Include(a => a.Cliente)
                .Include(a => a.Atendente).ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId)
        {
            return await _dbSet
                .Include(a => a.Cliente)
                .Include(a => a.Atendente)
                .Where(a => a.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetByAtendenteIdAsync(int atendenteId)
        {
            return await _dbSet
                .Include(a => a.Cliente)
                .Include(a => a.Atendente)
                .Where(a => a.AtendenteId == atendenteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetByDataAsync(DateTime data)
        {
            return await _dbSet
                .Include(a => a.Cliente)
                .Include(a => a.Atendente)
                .Where(a => a.DataHora.Date == data.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetByStatusAsync(string status)
        {
            return await _dbSet
                .Include(a => a.Cliente)
                .Include(a => a.Atendente)
                .Where(a => a.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetByAtendenteIdEDataAsync(int atendenteId, DateTime data)
        {
            return await _dbSet
                .Include(a => a.Cliente)
                .Include(a => a.Atendente)
                .Where(a => a.AtendenteId == atendenteId && a.DataHora.Date == data.Date)
                .ToListAsync();
        }
    }
}