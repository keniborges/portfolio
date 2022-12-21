using Projetos.Domain.Entities;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.Data.Context;
using Projetos.Infra.Data.Data;
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

        public async Task Add(Projeto entidade)
        {
            await AddAsync(entidade);
            _uow.Commit();
        }
    }
}
