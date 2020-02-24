using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GoodStore.BussinessLogic.Abstractions.Services;
using GoodStore.BussinessLogic.DTOs;
using GoodStore.DataAccess.Interfaces;
using GoodStore.Domain.Entities;

namespace GoodStore.BussinessLogic.Implementation.Services
{
    public class GoodTypeService : IGoodTypeService
    {
        private readonly IRepository<GoodTypeEntity> _goodTypeRepository;
        private readonly IMapper _mapper;

        public GoodTypeService(IRepository<GoodTypeEntity> goodTypeRepository, IMapper mapper)
        {
            _goodTypeRepository = goodTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GoodTypeDto>> GetAllIncludeGoodsAsync()
        {
            var goods = await _goodTypeRepository.GetAllIncludeAsync(x => x.Goods);
            return _mapper.Map<IEnumerable<GoodTypeDto>>(goods);
        }

        public async Task<IEnumerable<GoodTypeDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GoodTypeDto>>(await _goodTypeRepository.GetAllAsync());
        }

        public async Task<GoodTypeDto> AddAsync(GoodTypeDto entity)
        {
            var addedEntity = _goodTypeRepository.Add(_mapper.Map<GoodTypeEntity>(entity));
            await _goodTypeRepository.SaveChangesAsync();
            return _mapper.Map<GoodTypeDto>(addedEntity);
        }

        public async Task<GoodTypeDto> UpdateAsync(GoodTypeDto entity)
        {
            _goodTypeRepository.Update(_mapper.Map<GoodTypeEntity>(entity));
            await _goodTypeRepository.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await _goodTypeRepository.DeleteAsync(id);
            await _goodTypeRepository.SaveChangesAsync();
        }
    }
}
