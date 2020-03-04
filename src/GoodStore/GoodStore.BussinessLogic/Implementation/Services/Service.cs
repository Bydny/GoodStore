using AutoMapper;
using GoodStore.BussinessLogic.Abstractions.Services;
using GoodStore.DataAccess.Interfaces;
using GoodStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodStore.BussinessLogic.Implementation.Services
{
    public class Service<TModel, TEntity> : IService<TModel, TEntity> where  TEntity : class, IEntity
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<TModel>>(await Repository.GetAllAsync());
        }

        public async Task<IEnumerable<TModel>> GetAllIncludeAsync(params string[] includes)
        {
            return Mapper.Map<IEnumerable<TModel>>(await Repository.GetAllIncludeAsync(includes));
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            return Mapper.Map<TModel>(await Repository.GetByIdAsync(id));
        }

        public async Task<TModel> AddAsync(TModel item)
        {
            var entity = Repository.Add(Mapper.Map<TEntity>(item));
            var affectedCount = await Repository.SaveChangesAsync();

            if (affectedCount < 1)
            {
                throw new InvalidOperationException($"Cannot save {item}.");
            }

            return Mapper.Map<TModel>(entity);
        }

        public async Task UpdateAsync(TModel item)
        {
            Repository.Update(Mapper.Map<TEntity>(item));

            var affectedCount = await Repository.SaveChangesAsync();

            if (affectedCount < 1)
            {
                throw new InvalidOperationException($"Cannot update {item}.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);

            var affectedCount = await Repository.SaveChangesAsync();

            if (affectedCount < 1)
            {
                throw new InvalidOperationException($"Cannot delete {id}.");
            }
        }
    }
}
