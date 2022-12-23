using Projetos.Domain.DTos;
using System.Threading.Tasks;

namespace Projetos.Service.Interfaces
{
    public interface IProjetoService
    {
        Task<bool> Remover(long projetoId);

        Task<bool> MudarStatus(ProjetoMudaStatusDTo status);

        Task<bool> Salvar(ProjetoDTo model);
    }
}
