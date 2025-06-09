using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using AutoMapper;

namespace AgendaCerta.Services
{
    public class ClienteService(IClienteRepository clienteRepository, IMapper mapper) : IClienteService
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ClienteResponse>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ClienteResponse>>(await _clienteRepository.GetAllAsync());
        }

        public async Task<ClienteResponse?> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteResponse?>(cliente);
        }

        public async Task<ClienteResponse?> GetByEmailAsync(string email)
        {
            var cliente = await _clienteRepository.GetByEmailAsync(email);
            return _mapper.Map<ClienteResponse?>(cliente);
        }

        public async Task<ClienteResponse?> GetByCPFAsync(string cpf)
        {
            var cliente = await _clienteRepository.GetByCPFAsync(cpf);
            return _mapper.Map<ClienteResponse?>(cliente);
        }

        public async Task<ClienteResponse> CreateAsync(ClienteRequest clienteRequest)
        {
            if (!await IsCPFUniqueAsync(clienteRequest.CPF))
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com este CPF.");
            }

            var cliente = _mapper.Map<Cliente>(clienteRequest);
            var createdCliente = await _clienteRepository.AddAsync(cliente);
            return _mapper.Map<ClienteResponse>(createdCliente);
        }

        public async Task<ClienteResponse> UpdateAsync(int id, ClienteRequest clienteRequest)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id) ?? throw new InvalidOperationException("Cliente não encontrado.");
            if (clienteRequest.CPF != cliente.CPF && !await IsCPFUniqueAsync(clienteRequest.CPF))
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com este CPF.");
            }

            _mapper.Map(clienteRequest, cliente);
            var updatedCliente = await _clienteRepository.UpdateAsync(cliente);
            return _mapper.Map<ClienteResponse>(updatedCliente);
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