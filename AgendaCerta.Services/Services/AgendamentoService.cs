using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using AutoMapper;

namespace AgendaCerta.Services
{
    public class AgendamentoService(IAgendamentoRepository agendamentoRepository, IMapper mapper) : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository = agendamentoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<AgendamentoResponse>> GetAllAsync()
        {
            var agendamentos = await _agendamentoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AgendamentoResponse>>(agendamentos);
        }

        public async Task<AgendamentoResponse?> GetByIdAsync(int id)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(id);
            return _mapper.Map<AgendamentoResponse>(agendamento);
        }

        public async Task<IEnumerable<AgendamentoResponse>> GetByClienteIdAsync(int clienteId)
        {
            var agendamentos = await _agendamentoRepository.GetByClienteIdAsync(clienteId);
            return _mapper.Map<IEnumerable<AgendamentoResponse>>(agendamentos);
        }

        public async Task<IEnumerable<AgendamentoResponse>> GetByAtendenteIdAsync(int atendenteId)
        {
            var agendamentos = await _agendamentoRepository.GetByAtendenteIdAsync(atendenteId);
            return _mapper.Map<IEnumerable<AgendamentoResponse>>(agendamentos);
        }

        public async Task<IEnumerable<AgendamentoResponse>> GetByDataAsync(DateTime data)
        {
            var agendamentos = await _agendamentoRepository.GetByDataAsync(data);
            return _mapper.Map<IEnumerable<AgendamentoResponse>>(agendamentos);
        }

        public async Task<IEnumerable<AgendamentoResponse>> GetByStatusAsync(string status)
        {
            var agendamentos = await _agendamentoRepository.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<AgendamentoResponse>>(agendamentos);
        }

        public async Task<AgendamentoResponse> CreateAsync(AgendamentoRequest agendamentoRequest)
        {
            if (!await IsHorarioDisponivelAsync(agendamentoRequest.AtendenteId, agendamentoRequest.DataHora))
                throw new InvalidOperationException("Horário não disponível para este atendente");

            var agendamento = _mapper.Map<Agendamento>(agendamentoRequest);
            var createdAgendamento = await _agendamentoRepository.AddAsync(agendamento);
            return _mapper.Map<AgendamentoResponse>(createdAgendamento);
        }

        public async Task<AgendamentoResponse> UpdateAsync(int id, AgendamentoUpdateRequest agendamentoUpdateRequest)
        {
            var existingAgendamento = await _agendamentoRepository.GetByIdAsync(id);
            if (existingAgendamento == null)
                throw new InvalidOperationException("Agendamento não encontrado");

            if (existingAgendamento.DataHora != agendamentoUpdateRequest.DataHora || 
                existingAgendamento.AtendenteId != agendamentoUpdateRequest.AtendenteId)
            {
                if (!await IsHorarioDisponivelAsync(agendamentoUpdateRequest.AtendenteId, agendamentoUpdateRequest.DataHora))
                    throw new InvalidOperationException("Horário não disponível para este atendente");
            }

            _mapper.Map(agendamentoUpdateRequest, existingAgendamento);
            var updatedAgendamento = await _agendamentoRepository.UpdateAsync(existingAgendamento);
            return _mapper.Map<AgendamentoResponse>(updatedAgendamento);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(id);
            if (agendamento == null)
                return false;

            if (!await CanCancelAsync(id))
                throw new InvalidOperationException("Não é possível cancelar este agendamento");

            await _agendamentoRepository.DeleteAsync(agendamento);
            return true;
        }

        private async Task<bool> IsHorarioDisponivelAsync(int atendenteId, DateTime dataHora)
        {
            var agendamentosDoHorario = await _agendamentoRepository.GetByAtendenteIdEDataAsync(atendenteId, dataHora);
            return !agendamentosDoHorario.Any();
        }

        private async Task<bool> CanCancelAsync(int id)
        {
            var agendamento = await _agendamentoRepository.GetByIdAsync(id);
            if (agendamento == null)
                return false;

            // Não permite cancelar agendamentos que já aconteceram
            if (agendamento.DataHora < DateTime.Now)
                return false;

            // Não permite cancelar agendamentos com menos de 24 horas de antecedência
            if (agendamento.DataHora.Subtract(DateTime.Now).TotalHours < 24)
                return false;

            return true;
        }
    }
}