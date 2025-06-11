using AgendaCerta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AgendaCerta.Services.Interfaces;
using AgendaCerta.Services.DTOs;

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
        public async Task<ActionResult<IEnumerable<AgendamentoResponse>>> GetAll()
        {
            var agendamentos = await _agendamentoService.GetAllAsync();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoResponse>> GetById(int id)
        {
            var agendamento = await _agendamentoService.GetByIdAsync(id);
            if (agendamento == null)
                return NotFound();
            return Ok(agendamento);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<AgendamentoResponse>>> GetByClienteId(int clienteId)
        {
            var agendamentos = await _agendamentoService.GetByClienteIdAsync(clienteId);
            return Ok(agendamentos);
        }

        [HttpGet("atendente/{atendenteId}")]
        public async Task<ActionResult<IEnumerable<AgendamentoResponse>>> GetByAtendenteId(int atendenteId)
        {
            var agendamentos = await _agendamentoService.GetByAtendenteIdAsync(atendenteId);
            return Ok(agendamentos);
        }

        [HttpGet("data/{data}")]
        public async Task<ActionResult<IEnumerable<AgendamentoResponse>>> GetByData(DateTime data)
        {
            var agendamentos = await _agendamentoService.GetByDataAsync(data);
            return Ok(agendamentos);
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> Create([FromBody] AgendamentoRequest agendamentoRequest)
        {
            try
            {
                var createdAgendamento = await _agendamentoService.CreateAsync(agendamentoRequest);
                return CreatedAtAction(nameof(GetById), new { id = createdAgendamento.Id }, createdAgendamento);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Agendamento>> Update(int id, [FromBody] AgendamentoUpdateRequest agendamentoUpdateRequest)
        {
            try
            {
                var updatedAgendamento = await _agendamentoService.UpdateAsync(id, agendamentoUpdateRequest);
                return Ok(updatedAgendamento);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _agendamentoService.DeleteAsync(id);
            return NoContent();
        }
    }
}