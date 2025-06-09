using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendaCerta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendenteController : ControllerBase
    {
        private readonly IAtendenteService _atendenteService;

        public AtendenteController(IAtendenteService atendenteService)
        {
            _atendenteService = atendenteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtendenteResponse>>> GetAll()
        {
            var atendentes = await _atendenteService.GetAllAsync();
            return Ok(atendentes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AtendenteResponse>> GetById(int id)
        {
            var atendente = await _atendenteService.GetByIdAsync(id);
            if (atendente == null)
                return NotFound();
            return Ok(atendente);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<ClienteResponse>> GetByCPF(string cpf)
        {
            var cliente = await _atendenteService.GetByCPFAsync(cpf);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("especialidade/{especialidade}")]
        public async Task<ActionResult<IEnumerable<AtendenteResponse>>> GetByEspecialidade(string especialidade)
        {
            var atendentes = await _atendenteService.GetByEspecialidadeAsync(especialidade);
            return Ok(atendentes);
        }

        [HttpPost]
        public async Task<ActionResult<AtendenteResponse>> Create([FromBody] AtendenteRequest createAtendenteDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _atendenteService.CreateAsync(createAtendenteDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro ao criar o atendente. ex: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AtendenteResponse>> Update(int id, [FromBody] AtendenteRequest createAtendenteDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _atendenteService.UpdateAsync(id, createAtendenteDto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro ao atualizar o atendente. ex:{ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _atendenteService.DeleteAsync(id);
            return NoContent();
        }
    }
}