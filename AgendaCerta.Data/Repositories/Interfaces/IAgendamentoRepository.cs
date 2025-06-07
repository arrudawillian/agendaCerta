using AgendaCerta.Domain.Entities;

namespace AgendaCerta.Data.Repositories.Interfaces
{
    public interface IAgendamentoRepository : IBaseRepository<Agendamento>
    {
        Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Agendamento>> GetByAtendenteIdAsync(int atendenteId);
        Task<IEnumerable<Agendamento>> GetByAtendenteIdEDataAsync(int atendenteId, DateTime data);
        Task<IEnumerable<Agendamento>> GetByStatusAsync(string status);
        Task<IEnumerable<Agendamento>> GetByDataAsync(DateTime data);
    }
}