using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Interfaces;

namespace GoodStore.DataAccess.Interfaces
{
    public interface IRepository<T> 
        where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllIncludeAsync(params string[] includes);
        Task<IEnumerable<T>> GetAllIncludeAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> FilterIncludeAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        Task<IEnumerable<T>> FilterIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        T Add(T item);
        void Update(T item);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
