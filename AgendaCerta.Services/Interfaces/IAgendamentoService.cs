using AgendaCerta.Domain.Entities;

namespace AgendaCerta.Services.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
        Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Agendamento>> GetByAtendenteIdAsync(int atendenteId);
        Task<IEnumerable<Agendamento>> GetByDataAsync(DateTime data);
        Task<IEnumerable<Agendamento>> GetByStatusAsync(string status);
        Task<Agendamento> CreateAsync(Agendamento agendamento);
        Task<Agendamento> UpdateAsync(Agendamento agendamento);
        Task<bool> DeleteAsync(int id);
    }
}