using AutoMapper;
using GoodStore.BussinessLogic.Abstractions.Services;
using GoodStore.BussinessLogic.DTOs;
using GoodStore.DataAccess.Interfaces;
using GoodStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodStore.BussinessLogic.Implementation.Services
{
    public class GoodService : Service<GoodDto, GoodEntity>, IGoodService
    {
        public GoodService(
            IRepository<GoodEntity> repository,
            IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<IEnumerable<GoodDto>> GetFilteredByTypeAsync(int typeId)
        {
            var goods = await Repository.FilterIncludeAsync(x => x.GoodTypeId == typeId, string.Empty);
            return Mapper.Map<IEnumerable<GoodDto>>(goods);
        }

        public async Task<IEnumerable<GoodDto>> GetStartedWithNameAsync(string subName)
        {
            var goods = await Repository.FilterIncludeAsync(x => x.Name.StartsWith(subName), string.Empty);
            return Mapper.Map<IEnumerable<GoodDto>>(goods);
        }
    }
}
