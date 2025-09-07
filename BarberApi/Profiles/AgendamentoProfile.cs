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
            CreateMap<CreateAgendamentoDto, Agendamento>();
            CreateMap<UpdateAgendamentoDto, Agendamento>();
        }
    }
}
