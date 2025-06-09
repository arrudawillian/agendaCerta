using AutoMapper;
using AgendaCerta.Domain.Entities;
using AgendaCerta.Services.DTOs;

namespace AgendaCerta.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteRequest, Cliente>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Agendamentos, opt => opt.MapFrom(src => new List<Agendamento>()));
            
            CreateMap<Cliente, ClienteResponse>();

            CreateMap<AtendenteRequest, Atendente>()
                .ForMember(dest => dest.DataContratacao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Agendamentos, opt => opt.MapFrom(src => new List<Agendamento>()));

            CreateMap<Atendente, AtendenteResponse>();             

            CreateMap<AgendamentoRequest, Agendamento>()
                .ForMember(dest => dest.DataCriacao, opt => opt.MapFrom(src => DateTime.Now));
            
            CreateMap<AgendamentoUpdateRequest, Agendamento>()
                .ForMember(dest => dest.DataAtualizacao, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.ClienteId, opt => opt.Ignore()); // Impede a alteração do cliente
        }
    }
}