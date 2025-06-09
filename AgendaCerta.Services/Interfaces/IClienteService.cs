using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

namespace AgendaCerta.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponse>> GetAllAsync();
        Task<ClienteResponse?> GetByIdAsync(int id);
        Task<ClienteResponse?> GetByEmailAsync(string email);
        Task<ClienteResponse?> GetByCPFAsync(string cpf);
        Task<ClienteResponse> CreateAsync(ClienteRequest clienteRequest);
        Task<ClienteResponse> UpdateAsync(int id, ClienteRequest clienteRequest);
        Task<bool> DeleteAsync(int id);
    }
}