using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using AutoMapper;

namespace AgendaCerta.Services

{
    public class AtendenteService(IAtendenteRepository atendenteRepository, IMapper mapper) : IAtendenteService
    {
        private readonly IAtendenteRepository _atendenteRepository = atendenteRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<AtendenteResponse>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<AtendenteResponse>>(await _atendenteRepository.GetAllAsync());
        }

        public async Task<AtendenteResponse?> GetByIdAsync(int id)
        {
            var atendente = await _atendenteRepository.GetByIdAsync(id);
            return _mapper.Map<AtendenteResponse?>(atendente);
        }

        public async Task<AtendenteResponse?> GetByCPFAsync(string cpf)
        {
            var atendente = await _atendenteRepository.GetByCPFAsync(cpf);
            return _mapper.Map<AtendenteResponse?>(atendente);
        }

        public async Task<IEnumerable<AtendenteResponse?>> GetByEspecialidadeAsync(string especialidade)
        {
            var atendentes = await _atendenteRepository.GetByEspecialidadeAsync(especialidade);
            return _mapper.Map<IEnumerable<AtendenteResponse>>(atendentes);
        }

        public async Task<AtendenteResponse> CreateAsync(AtendenteRequest createAtendenteDto)
        {
            // Valida CPF único
            if (!await IsCPFUniqueAsync(createAtendenteDto.CPF))
            {
                throw new InvalidOperationException("Já existe um atendente cadastrado com este CPF.");
            }

            var atendente = _mapper.Map<Atendente>(createAtendenteDto);
            var createdAtendente = await _atendenteRepository.AddAsync(atendente);
            return _mapper.Map<AtendenteResponse>(createdAtendente);
        }

        public async Task<AtendenteResponse> UpdateAsync(int id, AtendenteRequest createAtendenteDto)
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

            var updatedAtendente = await _atendenteRepository.UpdateAsync(atendente);
            return _mapper.Map<AtendenteResponse>(updatedAtendente);
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