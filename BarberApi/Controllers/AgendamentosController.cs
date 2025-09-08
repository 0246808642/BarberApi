using BarberApi.Data.Dtos.AgendamentoDto;
using BarberApi.Service.Agendamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BarberApi.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class AgendamentosController : ControllerBase
{
    private readonly IAgendamento _service;
    public AgendamentosController(IAgendamento service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CreateAgendamentoDto dto)
    {
        var agendamento = await _service.Criar(dto);
        return CreatedAtAction(nameof(BuscarId), new { id = agendamento.ClientId }, agendamento);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var agendamentos = await _service.Listar();
        return Ok(agendamentos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarId(int id)
    {
        var agendamento = await _service.BuscarPorId(id);
        if (agendamento == null)
        {
            return NotFound("Agendamento não encontrado");
        }
        return Ok(agendamento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateAgendamentoDto dto)
    {
        var agendamentoAtualizado = await _service.Atualizar(id, dto);
        if (agendamentoAtualizado == null)
        {
            return NotFound("Agendamento não encontrado");
        }
        return Ok(agendamentoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var resultado = await _service.Remove(id);
        if (!resultado)
        {
            return NotFound("Agendamento não encontrado");
        }
        return NoContent();
    }
}
