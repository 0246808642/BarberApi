using AutoMapper;
using BarberApi.Data.Dtos.AgendamentoDto;
using BarberApi.Data.Dtos.ClienteDto;
using BarberApi.Models;

namespace BarberApi.Profiles
{
    public class ClienteProfile: Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ReadClienteDto>();
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
