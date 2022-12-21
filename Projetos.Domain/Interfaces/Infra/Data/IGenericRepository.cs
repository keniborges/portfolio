using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Projetos.Domain.Interfaces.Infra.Data
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task<T> SaveAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task Delete(long id);
        Task<bool> Existe(long id);
        Task<T> GetById(long id);
    }
}
