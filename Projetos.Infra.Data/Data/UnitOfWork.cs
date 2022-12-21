using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Infra.Data.Context;
using System.Linq;

namespace Projetos.Infra.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjetoContext _dbContext;


        public UnitOfWork(ProjetoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
