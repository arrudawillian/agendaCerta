using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using AutoMapper;

namespace AgendaCerta.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            return await _clienteRepository.GetByEmailAsync(email);
        }

        public async Task<Cliente?> GetByCPFAsync(string cpf)
        {
            return await _clienteRepository.GetByCPFAsync(cpf);
        }

        public async Task<Cliente> CreateAsync(CreateClienteDto clienteDto)
        {
            // Valida CPF único
            if (!await IsCPFUniqueAsync(clienteDto.CPF))
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com este CPF.");
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);
            return await _clienteRepository.AddAsync(cliente);
        }

        public async Task<Cliente> UpdateAsync(int id, CreateClienteDto clienteDto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                throw new InvalidOperationException("Cliente não encontrado.");
            }

            // Verifica se o CPF foi alterado e se já existe
            if (clienteDto.CPF != cliente.CPF && !await IsCPFUniqueAsync(clienteDto.CPF))
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com este CPF.");
            }

            // Atualiza as propriedades do cliente
            _mapper.Map(clienteDto, cliente);

            return await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return false;

            await _clienteRepository.DeleteAsync(cliente);
            return true;
        }

        private async Task<bool> IsCPFUniqueAsync(string cpf)
        {
            var cliente = await _clienteRepository.GetByCPFAsync(cpf);
            return cliente == null;
        }
    }
}