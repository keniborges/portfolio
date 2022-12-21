using Projetos.Domain.Entities;
using System.Threading.Tasks;

namespace Projetos.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<bool> Salvar(Funcionario entidade);
     }
}
