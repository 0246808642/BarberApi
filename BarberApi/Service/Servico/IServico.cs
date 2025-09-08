using BarberApi.Data.Dtos.ServicoDto;

namespace BarberApi.Service.Servico
{
    public interface IServico
    {
        Task<ReadServicoDto> Atualizar(long id, UpdateServicoDto dto);
        Task<ReadServicoDto> BuscarPorId(long id);
        Task<ReadServicoDto> Criar(CreateServicoDto dto);
        Task<List<ReadServicoDto>> Listar();
        Task<bool> Remove(long id);
    }
}
