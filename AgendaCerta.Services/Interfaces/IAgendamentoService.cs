using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

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
        Task<Agendamento> CreateAsync(AgendamentoRequest agendamentoRequest);
        Task<Agendamento> UpdateAsync(int id, AgendamentoUpdateRequest agendamentoUpdateRequest);
        Task<bool> DeleteAsync(int id);
    }
}