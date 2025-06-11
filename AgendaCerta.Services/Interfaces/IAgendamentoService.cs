using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

namespace AgendaCerta.Services.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<AgendamentoResponse>> GetAllAsync();
        Task<AgendamentoResponse?> GetByIdAsync(int id);
        Task<IEnumerable<AgendamentoResponse>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<AgendamentoResponse>> GetByAtendenteIdAsync(int atendenteId);
        Task<IEnumerable<AgendamentoResponse>> GetByDataAsync(DateTime data);
        Task<IEnumerable<AgendamentoResponse>> GetByStatusAsync(string status);
        Task<AgendamentoResponse> CreateAsync(AgendamentoRequest agendamentoRequest);
        Task<AgendamentoResponse> UpdateAsync(int id, AgendamentoUpdateRequest agendamentoUpdateRequest);
        Task<bool> DeleteAsync(int id);
    }
}