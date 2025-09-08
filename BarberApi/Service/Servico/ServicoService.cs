using AutoMapper;
using BarberApi.Data;
using BarberApi.Data.Dtos.ClienteDto;
using BarberApi.Data.Dtos.ServicoDto;
using Microsoft.EntityFrameworkCore;

namespace BarberApi.Service.Servico
{
    public class ServicoService : IServico
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ServicoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReadServicoDto> Atualizar(long id, UpdateServicoDto dto)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null) return null;
            _mapper.Map(dto, servico);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadServicoDto>(servico);
        }

        public async Task<ReadServicoDto> BuscarPorId(long id)
        {
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null) return null;
            return _mapper.Map<ReadServicoDto>(servico);
        }

        public async Task<ReadServicoDto> Criar(CreateServicoDto dto)
        {
           var servico = _mapper.Map<Models.Servico>(dto);
   
            await _context.Servicos.AddAsync(servico);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReadServicoDto>(servico);
        }

        public async Task<List<ReadServicoDto>> Listar()
        {
           var servico = await _context.Servicos.ToListAsync();
            if (!servico.Any()) return new List<ReadServicoDto>();
            return _mapper.Map<List<ReadServicoDto>>(servico);

        }

        public async Task<bool> Remove(long id)
        {
           var servico = await _context.Servicos.FindAsync(id);
            if (servico == null) return false;
            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
