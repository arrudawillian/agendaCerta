using AgendaCerta.Domain.Entities;

namespace AgendaCerta.Services.Interfaces
{
    public interface IAtendenteService
    {
        Task<IEnumerable<Atendente>> GetAllAsync();
        Task<Atendente?> GetByIdAsync(int id);
        Task<Atendente?> GetByEmailAsync(string email);
        Task<Atendente?> GetByCPFAsync(string cpf);
        Task<IEnumerable<Atendente?>> GetByEspecialidadeAsync(string especialidade);
        Task<Atendente> CreateAsync(Atendente atendente);
        Task<Atendente> UpdateAsync(Atendente atendente);
        Task<bool> DeleteAsync(int id);
    }
}