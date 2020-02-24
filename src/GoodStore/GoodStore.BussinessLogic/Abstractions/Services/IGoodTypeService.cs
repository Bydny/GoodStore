using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.BussinessLogic.DTOs;
using GoodStore.Domain.Entities;

namespace GoodStore.BussinessLogic.Abstractions.Services
{
    public interface IGoodTypeService
    {
        Task<IEnumerable<GoodTypeDto>> GetAllIncludeGoodsAsync();
        Task<IEnumerable<GoodTypeDto>> GetAllAsync();
        Task<GoodTypeDto> AddAsync(GoodTypeDto entity);
        Task<GoodTypeDto> UpdateAsync(GoodTypeDto entity);
        Task DeleteAsync(int id);
    }
}
