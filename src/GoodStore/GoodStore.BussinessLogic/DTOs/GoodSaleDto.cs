using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodStore.BussinessLogic.DTOs
{
    public class GoodSaleDto
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public GoodDto Good { get; set; }
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        public int GoodAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
