using Projetos.Domain.Entities;
using System.Threading.Tasks;

namespace Projetos.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task Add(Projeto entidade);
    }
}
