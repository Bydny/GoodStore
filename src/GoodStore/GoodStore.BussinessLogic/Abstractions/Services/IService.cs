using GoodStore.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodStore.BussinessLogic.Abstractions.Services
{
    public interface IService<TModel, TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<IEnumerable<TModel>> GetAllIncludeAsync(params string[] includes);
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> AddAsync(TModel item);
        Task UpdateAsync(TModel item);
        Task DeleteAsync(int id);
    }
}
