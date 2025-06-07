using AgendaCerta.Domain.Entities;
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
        public async Task<ActionResult<IEnumerable<Atendente>>> GetAll()
        {
            var atendentes = await _atendenteService.GetAllAsync();
            return Ok(atendentes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Atendente>> GetById(int id)
        {
            var atendente = await _atendenteService.GetByIdAsync(id);
            if (atendente == null)
                return NotFound();
            return Ok(atendente);
        }

        [HttpPost]
        public async Task<ActionResult<Atendente>> Create([FromBody] Atendente atendente)
        {
            var createdAtendente = await _atendenteService.CreateAsync(atendente);
            return CreatedAtAction(nameof(GetById), new { id = createdAtendente.Id }, createdAtendente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Atendente atendente)
        {
            if (id != atendente.Id)
                return BadRequest();

            await _atendenteService.UpdateAsync(atendente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _atendenteService.DeleteAsync(id);
            return NoContent();
        }
    }
}