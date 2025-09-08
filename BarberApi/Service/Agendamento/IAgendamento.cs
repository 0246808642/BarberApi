using BarberApi.Data.Dtos.AgendamentoDto;

namespace BarberApi.Service.Agendamento
{
    public interface IAgendamento
    {
        public Task<ReadAgendamentoDto> Criar(CreateAgendamentoDto dto);
        public Task<List<ReadAgendamentoDto>> Listar();
        public Task<ReadAgendamentoDto> BuscarPorId(long id);
        public Task<ReadAgendamentoDto> Atualizar(long id, UpdateAgendamentoDto dto);
        Task<bool> Remove(long id);
    }
}
