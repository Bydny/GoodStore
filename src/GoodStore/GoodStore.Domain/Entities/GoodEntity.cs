using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Interfaces;

namespace GoodStore.Domain.Entities
{
    public class GoodEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime IncomingDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public StoreUserEntity User { get; set; }
        public int GoodTypeId { get; set; }
        public GoodTypeEntity GoodType { get; set; }
        public int GoodSellerId { get; set; }
        public GoodSellerEntity GoodSeller { get; set; }
        public ICollection<GoodSaleEntity> GoodSales { get; set; }
    }
}
