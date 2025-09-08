using AutoMapper;
using BarberApi.Data;
using BarberApi.Data.Dtos.AgendamentoDto;
using System;
using BarberApi.Models;
using Microsoft.EntityFrameworkCore;
using BarberApi.Service.Servico;
using BarberApi.Data.Dtos.ClienteDto;
using BarberApi.Service.Cliente;

namespace BarberApi.Service.Agendamento;

public class AgendamentoService : IAgendamento
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public AgendamentoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ReadAgendamentoDto> Atualizar(long id, UpdateAgendamentoDto dto)
    {
        var agendamento = await _context.Agendamentos.FindAsync(id);
        if(agendamento == null)  return null;

        _mapper.Map(dto, agendamento);
        await _context.SaveChangesAsync();
        return _mapper.Map<ReadAgendamentoDto>(agendamento);
       
    }

    public  async Task<ReadAgendamentoDto> BuscarPorId(long id)
    {
        var agendamentoId = await _context.Agendamentos.FindAsync(id);
        if (agendamentoId == null) return null;
        return _mapper.Map<ReadAgendamentoDto>(agendamentoId);
    }

    public async Task<ReadAgendamentoDto> Criar(CreateAgendamentoDto dto)
    {
       var agendamento = _mapper.Map<Models.Agendamento>(dto);
        await _context.Agendamentos.AddAsync(agendamento);
        await _context.SaveChangesAsync();
        return _mapper.Map<ReadAgendamentoDto>(agendamento);
    }

    public async Task<List<ReadAgendamentoDto>> Listar()
    {
        var agendamentos = await _context.Agendamentos.ToListAsync();
        if (!agendamentos.Any()) return new List<ReadAgendamentoDto>();
        return _mapper.Map<List<ReadAgendamentoDto>>(agendamentos);
    }

    public async Task<bool> Remove(long id)
    {
        var agendamento = await _context.Agendamentos.FindAsync(id);
        if (agendamento == null) return false;
        _context.Agendamentos.Remove(agendamento);
        await _context.SaveChangesAsync();
        return true;
    }


}
