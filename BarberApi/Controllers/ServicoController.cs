using BarberApi.Data.Dtos.ServicoDto;
using BarberApi.Service.Servico;
using Microsoft.AspNetCore.Mvc;

namespace BarberApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServicoController : ControllerBase
{
    private readonly IServico _servico;
    public ServicoController(IServico servico)
    {
        _servico = servico;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CreateServicoDto dto)
    {
        var servico = await _servico.Criar(dto);
        return CreatedAtAction(nameof(BuscarPorId), new { id = servico }, servico);
    }

    [HttpGet]
    public async Task<IActionResult> Buscar()
    {
        var servicos = await _servico.Listar();
        return Ok(servicos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var servico = await _servico.BuscarPorId(id);
        if (servico == null) return NotFound();
        return Ok(servico);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateServicoDto dto)
    {
        var servico = await _servico.Atualizar(id, dto);
        if (servico == null) return NotFound();
        return Ok(servico);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var resultado = await _servico.Remove(id);
        if (!resultado) return NotFound();
        return NoContent();
    }

}
