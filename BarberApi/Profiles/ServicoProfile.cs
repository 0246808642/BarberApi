using AutoMapper;
using BarberApi.Data.Dtos.ServicoDto;
using BarberApi.Models;

namespace BarberApi.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<Servico, ReadServicoDto>();
            CreateMap<CreateServicoDto, Servico>();
            CreateMap<UpdateServicoDto, Servico>();
        }
    }
}
