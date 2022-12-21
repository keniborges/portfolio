using Projetos.Domain.DTos;

namespace Projetos.Service.Interfaces
{
    public interface IAutenticacaoService
    {
        LoginResponseDTo GetToken();
    }
}
