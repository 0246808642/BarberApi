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
            CreateMap<CreateClienteDto, Cliente>()
               .ForMember(dest => dest.ClientId, opt => opt.Ignore())
               .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento));

            CreateMap<Cliente, ReadClienteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientId));

            CreateMap<UpdateClienteDto, Cliente>()
                .ForMember(dest => dest.ClientId, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());

        }
    }
}
