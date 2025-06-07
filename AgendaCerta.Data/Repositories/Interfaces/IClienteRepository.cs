using AgendaCerta.Domain.Entities;

namespace AgendaCerta.Data.Repositories.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente?> GetByEmailAsync(string email);
        Task<Cliente?> GetByCPFAsync(string cpf);
    }
}