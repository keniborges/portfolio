using Projetos.Domain.Entities;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.Data.Context;
using Projetos.Infra.Data.Data;
using System.Threading.Tasks;

namespace Projetos.Infra.Data.Repositories
{
    public class FuncionarioRepository : GenericRepository<Funcionario>, IFuncionarioRepository
    {
        private readonly IUnitOfWork _uow;

        public FuncionarioRepository(ProjetoContext context, IUnitOfWork uow) : base(context)
        {
            this._uow = uow;
        }

        public async Task<bool> Salvar(Funcionario entidade)
        {
            try
            {
                if (entidade.Id == 0)
                    await AddAsync(entidade);
                else
                    Update(entidade);
                _uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}


