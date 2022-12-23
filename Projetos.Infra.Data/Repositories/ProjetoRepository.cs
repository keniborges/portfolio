using Projetos.Domain.Entities;
using Projetos.Domain.Enums;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.Data.Context;
using Projetos.Infra.Data.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos.Infra.Data.Repositories
{
    public class ProjetoRepository : GenericRepository<Projeto>, IProjetoRepository
    {
        private readonly IUnitOfWork _uow;

        public ProjetoRepository(ProjetoContext context, IUnitOfWork uow) : base(context)
        {
            this._uow = uow;
        }

        public async Task<bool> Salvar(Projeto entidade)
        {
            try
            {
                if (entidade.Id > 0)
                    Update(entidade);
                else
                    await AddAsync(entidade);
                _uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool AlterarStatus(Projeto projeto)
        {
            try
            {
                Update(projeto);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<Projeto> BuscarPorId(long id)
        {
            return await FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Remover(Projeto projeto)
        {
            Remove(projeto);
        }
    }
}
