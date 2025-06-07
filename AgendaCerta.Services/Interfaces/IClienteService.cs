using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

namespace AgendaCerta.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente?> GetByEmailAsync(string email);
        Task<Cliente?> GetByCPFAsync(string cpf);
        Task<Cliente> CreateAsync(CreateClienteDto clienteDto);
        Task<Cliente> UpdateAsync(int id, CreateClienteDto clienteDto);
        Task<bool> DeleteAsync(int id);
    }
}