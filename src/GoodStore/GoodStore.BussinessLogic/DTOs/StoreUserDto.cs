using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Enums;

namespace GoodStore.BussinessLogic.DTOs
{
    public class StoreUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public ICollection<GoodDto> Goods { get; set; }
    }
}
