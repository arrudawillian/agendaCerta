using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using AutoMapper;

namespace AgendaCerta.Services

{
    public class AtendenteService : IAtendenteService
    {
        private readonly IAtendenteRepository _atendenteRepository;
        private readonly IMapper _mapper;

        public AtendenteService(IAtendenteRepository atendenteRepository, IMapper mapper)
        {
            _atendenteRepository = atendenteRepository;
            _mapper = mapper;
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

        public async Task<Atendente> CreateAsync(CreateAtendenteDto createAtendenteDto)
        {
            // Valida CPF único
            if (!await IsCPFUniqueAsync(createAtendenteDto.CPF))
            {
                throw new InvalidOperationException("Já existe um atendente cadastrado com este CPF.");
            }

            var atendente = _mapper.Map<Atendente>(createAtendenteDto);
            return await _atendenteRepository.AddAsync(atendente);
        }

        public async Task<Atendente> UpdateAsync(int id, CreateAtendenteDto createAtendenteDto)
        {
            var atendente = await _atendenteRepository.GetByIdAsync(id);
            if (atendente == null)
            {
                throw new InvalidOperationException("Atendente não encontrado.");
            }

            // Verifica se o CPF foi alterado e se já existe
            if (createAtendenteDto.CPF != atendente.CPF && !await IsCPFUniqueAsync(createAtendenteDto.CPF))
            {
                throw new InvalidOperationException("Já existe um cliente cadastrado com este CPF.");
            }

            // Atualiza as propriedades do cliente
            _mapper.Map(createAtendenteDto, atendente);

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

        private async Task<bool> IsCPFUniqueAsync(string cpf)
        {
            var cliente = await _atendenteRepository.GetByCPFAsync(cpf);
            return cliente == null;
        }
    }
}