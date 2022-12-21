using Projetos.Domain.DTos;
using System.Threading.Tasks;

namespace Projetos.Service.Interfaces
{
    public interface IFuncionarioService
    {
        Task<bool> Salvar(FuncionarioDTo model);
    }
}
