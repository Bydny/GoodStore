﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodStore.BussinessLogic.DTOs
{
    public class GoodTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GoodDto> Goods { get; set; }
    }
}
