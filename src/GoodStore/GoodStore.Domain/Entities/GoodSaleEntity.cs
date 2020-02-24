using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Interfaces;

namespace GoodStore.Domain.Entities
{
    public class GoodSaleEntity : IEntity
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public GoodEntity Good { get; set; }
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public int GoodAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
