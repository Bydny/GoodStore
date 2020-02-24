using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Interfaces;

namespace GoodStore.Domain.Entities
{
    public class GoodTypeEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GoodEntity> Goods { get; set; }
    }
}
