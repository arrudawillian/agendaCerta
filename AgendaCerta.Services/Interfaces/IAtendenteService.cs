using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

namespace AgendaCerta.Services.Interfaces
{
    public interface IAtendenteService
    {
        Task<IEnumerable<Atendente>> GetAllAsync();
        Task<Atendente?> GetByIdAsync(int id);
        Task<Atendente?> GetByEmailAsync(string email);
        Task<Atendente?> GetByCPFAsync(string cpf);
        Task<IEnumerable<Atendente?>> GetByEspecialidadeAsync(string especialidade);
        Task<Atendente> CreateAsync(CreateAtendenteDto createAtendenteDto);
        Task<Atendente> UpdateAsync(int id, CreateAtendenteDto createAtendenteDto);
        Task<bool> DeleteAsync(int id);
    }
}