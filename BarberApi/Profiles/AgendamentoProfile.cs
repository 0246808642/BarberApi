using AutoMapper;
using BarberApi.Data.Dtos.AgendamentoDto;
using BarberApi.Models;

namespace BarberApi.Profiles
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Agendamento, ReadAgendamentoDto>();

            CreateMap<CreateAgendamentoDto, Agendamento>()
                .ForMember(dest => dest.AgendamentoId, opt => opt.Ignore()) 
                .ForMember(dest => dest.Cliente, opt => opt.Ignore()) // Navigation property
                .ForMember(dest => dest.Servicios, opt => opt.Ignore()) // Collection
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateAgendamentoDto, Agendamento>().ForMember(dest => dest.AgendamentoId, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Servicios, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());

        }
    }
}
