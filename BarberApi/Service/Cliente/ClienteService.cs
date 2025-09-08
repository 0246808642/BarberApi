using AutoMapper;
using BarberApi.Data;
using BarberApi.Data.Dtos.ClienteDto;
using BarberApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberApi.Service.Cliente
{
    public class ClienteService : ICliente
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadClienteDto> Atualizar(long id, UpdateClienteDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;
            _mapper.Map(dto, cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadClienteDto>(cliente);

        }

        public async Task<ReadClienteDto> BuscarPorId(long id)
        {
           var cliente = await _context.Clientes.FindAsync(id); 
            if (cliente == null) return null;
            return _mapper.Map<ReadClienteDto>(cliente);

        }

        public async Task<ReadClienteDto> Criar(CreateClienteDto dto)
        {
            var cliente = _mapper.Map<Models.Cliente>(dto);
            if (cliente != null)
            {
                throw new InvalidOperationException($"Já existe um cliente cadastrado com o email: {dto.Email}");
            }
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadClienteDto>(cliente);

        }

        public async Task<List<ReadClienteDto>> Listar()
        {
           var cliente = await _context.Clientes.ToListAsync();
            if (!cliente.Any()) return new List<ReadClienteDto>();
            return _mapper.Map<List<ReadClienteDto>>(cliente);
        }

        public async Task<bool> Remove(long id)
        {
           var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
