using AutoMapper;
using Projetos.Domain.DTos;
using Projetos.Domain.Entities;
using Projetos.Domain.Enums;

namespace Projetos.Service.Mappers
{
    public class ProjetoMapper : Profile
    {
        public ProjetoMapper()
        {
            CreateMap<ProjetoDTo, Projeto>()
                .ForMember(dest => dest.Classificacao, opt => opt.MapFrom(src => ClassificacaoEnum.BaixoRisco));
        }
    }
}


