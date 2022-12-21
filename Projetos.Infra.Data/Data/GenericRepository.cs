using Microsoft.EntityFrameworkCore;
using Projetos.Domain.Entities;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Projetos.Infra.Data.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ProjetoContext _context;

        public GenericRepository(ProjetoContext context)
        {
            _context = context;
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => _context.Set<T>().FirstOrDefaultAsync(predicate);

        public Task<T> FirstOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> predicate) => _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        public IQueryable<T> Query() => _context.Set<T>().AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public IQueryable<T> GetAll() => _context.Set<T>();

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> SaveAsync(T entity)
        {

            if ((entity as BaseEntity).Id == 0)
                await AddAsync(entity);
            else
                Update(entity);

            return entity;
        }

        public async Task Delete(long id)
        {
            Remove(await FirstOrDefaultAsync(e => e.Id == id));
        }

        public async Task<bool> Existe(long id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<T> GetById(long id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
