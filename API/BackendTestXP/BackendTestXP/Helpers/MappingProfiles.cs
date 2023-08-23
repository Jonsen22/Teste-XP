using AutoMapper;
using BackendTestXP.DTOs;
using XPTesteAPI.Entities;

namespace BackendTestXP.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Endereco, EnderecoDTO>();
            CreateMap<EnderecoAdicionarDTO, Endereco>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Email, EmailDTO>();
            CreateMap<EmailAdicionarDTO, Email>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteAdicionarDTO, Cliente>()            
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Cliente, ClienteDetalhesDTO>()
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.Emails, opt => opt.MapFrom(src => src.Emails));

        }
    }
}
