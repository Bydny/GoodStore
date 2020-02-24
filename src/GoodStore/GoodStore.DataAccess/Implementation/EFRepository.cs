using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GoodStore.DataAccess.Interfaces;
using GoodStore.Domain.Interfaces;

namespace GoodStore.DataAccess.Implementation
{ 
    public class EfRepository<T> : IRepository<T> 
        where T : class, IEntity
    {
        protected readonly DbContext Context;

        public EfRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllIncludeAsync(params string[] includes)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllIncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterIncludeAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        public T Add(T item)
        {
            return Context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            var entry = Context.Entry(item);
            Context.Set<T>().Attach(item);
            entry.State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            Context.Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
