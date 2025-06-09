using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

namespace AgendaCerta.Services.Interfaces
{
    public interface IAtendenteService
    {
        Task<IEnumerable<AtendenteResponse>> GetAllAsync();
        Task<AtendenteResponse?> GetByIdAsync(int id);
        Task<AtendenteResponse?> GetByCPFAsync(string cpf);
        Task<IEnumerable<AtendenteResponse?>> GetByEspecialidadeAsync(string especialidade);
        Task<AtendenteResponse> CreateAsync(AtendenteRequest createAtendenteDto);
        Task<AtendenteResponse> UpdateAsync(int id, AtendenteRequest createAtendenteDto);
        Task<bool> DeleteAsync(int id);
    }
}