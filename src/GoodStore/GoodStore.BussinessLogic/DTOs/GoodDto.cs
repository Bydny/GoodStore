using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodStore.BussinessLogic.DTOs
{
    public class GoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime IncomingDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public StoreUserDto User { get; set; }
        public int GoodTypeId { get; set; }
        public GoodTypeDto GoodType { get; set; }
        public int GoodSellerId { get; set; }
        public GoodSellerDto GoodSeller { get; set; }
        public ICollection<GoodSaleDto> GoodSales { get; set; }
    }
}
