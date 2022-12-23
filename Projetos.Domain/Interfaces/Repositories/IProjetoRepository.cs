using Projetos.Domain.Entities;
using System.Threading.Tasks;

namespace Projetos.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        void Remover(Projeto projeto);

        bool AlterarStatus(Projeto projeto);

        Task<bool> Salvar(Projeto entidade);

        Task<Projeto> BuscarPorId(long id);
    }
}
