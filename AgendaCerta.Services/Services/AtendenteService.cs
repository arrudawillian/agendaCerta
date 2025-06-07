using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.Interfaces;

namespace AgendaCerta.Services
{
    public class AtendenteService : IAtendenteService
    {
        private readonly IAtendenteRepository _atendenteRepository;

        public AtendenteService(IAtendenteRepository atendenteRepository)
        {
            _atendenteRepository = atendenteRepository;
        }

        public async Task<IEnumerable<Atendente>> GetAllAsync()
        {
            return await _atendenteRepository.GetAllAsync();
        }

        public async Task<Atendente?> GetByIdAsync(int id)
        {
            return await _atendenteRepository.GetByIdAsync(id);
        }

        public async Task<Atendente?> GetByEmailAsync(string email)
        {
            return await _atendenteRepository.GetByEmailAsync(email);
        }

        public async Task<Atendente?> GetByCPFAsync(string cpf)
        {
            return await _atendenteRepository.GetByCPFAsync(cpf);
        }

        public async Task<IEnumerable<Atendente?>> GetByEspecialidadeAsync(string especialidade)
        {
            return await _atendenteRepository.GetByEspecialidadeAsync(especialidade);
        }

        public async Task<Atendente> CreateAsync(Atendente atendente)
        {
            return await _atendenteRepository.AddAsync(atendente);
        }

        public async Task<Atendente> UpdateAsync(Atendente atendente)
        {
            return await _atendenteRepository.UpdateAsync(atendente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var atendente = await _atendenteRepository.GetByIdAsync(id);
            if (atendente == null)
                return false;

            await _atendenteRepository.DeleteAsync(atendente);
            return true;
        }
    }
}