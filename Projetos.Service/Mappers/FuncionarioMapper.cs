using AutoMapper;
using Projetos.Domain.DTos;
using Projetos.Domain.Entities;

namespace Projetos.Service.Mappers
{
    public class FuncionarioMapper : Profile
    {
        public FuncionarioMapper()
        {
            CreateMap<FuncionarioDTo, Funcionario>();
        }
    }
}
