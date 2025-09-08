using BarberApi.Data.Dtos.ClienteDto;

namespace BarberApi.Service.Cliente
{
    public interface ICliente
    {
        Task<ReadClienteDto> Atualizar(long id, UpdateClienteDto dto);
        Task<ReadClienteDto> BuscarPorId(long id);
        Task<ReadClienteDto> Criar(CreateClienteDto dto);
        Task<List<ReadClienteDto>> Listar();
        Task<bool> Remove(long id);
    }
}
