using GoodStore.BussinessLogic.DTOs;
using GoodStore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodStore.BussinessLogic.Abstractions.Services
{
    public interface IGoodService : IService<GoodDto, GoodEntity>
    {
        Task<IEnumerable<GoodDto>> GetFilteredByTypeAsync(int typeId);

        Task<IEnumerable<GoodDto>> GetStartedWithNameAsync(string subName);
    }
}
