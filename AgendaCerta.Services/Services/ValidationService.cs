using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Services.Interfaces;

namespace AgendaCerta.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IClienteRepository _clienteRepository;

        public ValidationService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> IsCPFUniqueAsync(string cpf)
        {
            var cliente = await _clienteRepository.GetByCPFAsync(cpf);
            return cliente == null;
        }
    }
}