using AutoMapper;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

namespace AgendaCerta.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateClienteDto, Cliente>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Agendamentos, opt => opt.MapFrom(src => new List<Agendamento>()));
        }
    }
}