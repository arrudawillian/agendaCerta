using AgendaCerta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AgendaCerta.Services.Interfaces;

namespace AgendaCerta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAll()
        {
            var agendamentos = await _agendamentoService.GetAllAsync();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetById(int id)
        {
            var agendamento = await _agendamentoService.GetByIdAsync(id);
            if (agendamento == null)
                return NotFound();
            return Ok(agendamento);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetByClienteId(int clienteId)
        {
            var agendamentos = await _agendamentoService.GetByClienteIdAsync(clienteId);
            return Ok(agendamentos);
        }

        [HttpGet("atendente/{atendenteId}")]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetByAtendenteId(int atendenteId)
        {
            var agendamentos = await _agendamentoService.GetByAtendenteIdAsync(atendenteId);
            return Ok(agendamentos);
        }

        [HttpGet("data/{data}")]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetByData(DateTime data)
        {
            var agendamentos = await _agendamentoService.GetByDataAsync(data);
            return Ok(agendamentos);
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> Create([FromBody] Agendamento agendamento)
        {
            var createdAgendamento = await _agendamentoService.CreateAsync(agendamento);
            return CreatedAtAction(nameof(GetById), new { id = createdAgendamento.Id }, createdAgendamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Agendamento agendamento)
        {
            if (id != agendamento.Id)
                return BadRequest();

            await _agendamentoService.UpdateAsync(agendamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _agendamentoService.DeleteAsync(id);
            return NoContent();
        }
    }
}