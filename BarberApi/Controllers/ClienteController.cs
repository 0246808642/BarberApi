using BarberApi.Data.Dtos.ClienteDto;
using BarberApi.Service.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    
    public class ClienteController: ControllerBase
    {
        private readonly ICliente _service;
        public ClienteController(ICliente service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateClienteDto dto)
        {
            var cliente = await _service.Criar(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = cliente.Email }, cliente);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var cliente = await _service.BuscarPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var clientes = await _service.Listar();
            return Ok(clientes);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateClienteDto dto)
        {
            var cliente = await _service.Atualizar(id, dto);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var result = await _service.Remove(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
