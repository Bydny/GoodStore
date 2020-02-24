using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GoodStore.BussinessLogic.DTOs;
using GoodStore.Domain.Entities;

namespace GoodStore.BussinessLogic.Infrastructure.AutomapperProfiles
{
    public class StoreUserProfile : Profile
    {
        public StoreUserProfile()
        {
            CreateMap<StoreUserDto, StoreUserEntity>().ReverseMap();
        }
    }
}
