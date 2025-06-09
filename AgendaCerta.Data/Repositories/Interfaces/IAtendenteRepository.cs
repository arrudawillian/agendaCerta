using AgendaCerta.Domain.Entities;

namespace AgendaCerta.Data.Repositories.Interfaces
{
    public interface IAtendenteRepository : IBaseRepository<Atendente>
    {
        Task<Atendente?> GetByCPFAsync(string cpf);
        Task<IEnumerable<Atendente?>> GetByEspecialidadeAsync(string especialidade);
    }
}