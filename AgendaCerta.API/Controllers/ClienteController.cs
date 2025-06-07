using AgendaCerta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AgendaCerta.Services.DTOs;
using AgendaCerta.Services.Interfaces;
using AutoMapper;

namespace AgendaCerta.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<Cliente>> GetByCPF(string cpf)
        {
            var cliente = await _clienteService.GetByCPFAsync(cpf);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Cliente>> GetByEmail(string email)
        {
            var cliente = await _clienteService.GetByEmailAsync(email);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create([FromBody] CreateClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _clienteService.CreateAsync(clienteDto);
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
        public async Task<ActionResult<Cliente>> Update(int id, [FromBody] CreateClienteDto clienteDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _clienteService.UpdateAsync(id, clienteDto);
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
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}