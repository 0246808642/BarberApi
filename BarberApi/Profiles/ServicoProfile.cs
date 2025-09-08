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
            CreateMap<CreateServicoDto, Servico>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore()); 

            CreateMap<UpdateServicoDto, Servico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 
        }
    }
}
