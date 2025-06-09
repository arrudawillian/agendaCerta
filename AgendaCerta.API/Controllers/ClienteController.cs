using AgendaCerta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using AutoMapper;

namespace AgendaCerta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(IClienteService clienteService, IMapper mapper) : ControllerBase
    {
        private readonly IClienteService _clienteService = clienteService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponse>>> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponse>> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<ClienteResponse>> GetByCPF(string cpf)
        {
            var cliente = await _clienteService.GetByCPFAsync(cpf);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<ClienteResponse>> GetByEmail(string email)
        {
            var cliente = await _clienteService.GetByEmailAsync(email);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> Create([FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _clienteService.CreateAsync(clienteRequest);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro ao criar o cliente. ex: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteResponse>> Update(int id, [FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _clienteService.UpdateAsync(id, clienteRequest);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Ocorreu um erro ao atualizar o cliente. ex:{ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _clienteService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Cliente não encontrado." });
                    
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Erro ao excluir o cliente: {ex.Message}" });
            }
        }
    }
}