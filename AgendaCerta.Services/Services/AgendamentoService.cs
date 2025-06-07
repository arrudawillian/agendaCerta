using AgendaCerta.Data.Repositories.Interfaces;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.Interfaces;

namespace AgendaCerta.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            return await _agendamentoRepository.GetAllAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await _agendamentoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId)
        {
            return await _agendamentoRepository.GetByClienteIdAsync(clienteId);
        }

        public async Task<IEnumerable<Agendamento>> GetByAtendenteIdAsync(int atendenteId)
        {
            return await _agendamentoRepository.GetByAtendenteIdAsync(atendenteId);
        }

        public async Task<IEnumerable<Agendamento>> GetByDataAsync(DateTime data)
        {
            return await _agendamentoRepository.GetByDataAsync(data);
        }

        public async Task<IEnumerable<Agendamento>> GetByStatusAsync(string status)
        {
            return await _agendamentoRepository.GetByStatusAsync(status);
        }

        public async Task<Agendamento> CreateAsync(Agendamento agendamento)
        {
            if (!await IsHorarioDisponivelAsync(agendamento.AtendenteId, agendamento.DataHora))
                throw new InvalidOperationException("Horário não disponível para este atendente");

            return await _agendamentoRepository.AddAsync(agendamento);
        }

        public async Task<Agendamento> UpdateAsync(Agendamento agendamento)
        {
            var existingAgendamento = await GetByIdAsync(agendamento.Id);
            if (existingAgendamento == null)
                throw new InvalidOperationException("Agendamento não encontrado");

            if (existingAgendamento.DataHora != agendamento.DataHora || 
                existingAgendamento.AtendenteId != agendamento.AtendenteId)
            {
                if (!await IsHorarioDisponivelAsync(agendamento.AtendenteId, agendamento.DataHora))
                    throw new InvalidOperationException("Horário não disponível para este atendente");
            }

            agendamento.DataAtualizacao = DateTime.Now;
            return await _agendamentoRepository.UpdateAsync(agendamento);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var agendamento = await GetByIdAsync(id);
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
            var agendamento = await GetByIdAsync(id);
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