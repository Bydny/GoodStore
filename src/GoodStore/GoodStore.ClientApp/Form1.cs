﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoodStore.BussinessLogic.Abstractions.Services;
using GoodStore.BussinessLogic.DTOs;

namespace GoodStore.ClientApp
{
    public partial class Form1 : Form
    {
        private readonly IGoodTypeService _goodTypeService;

        public Form1(IGoodTypeService goodTypeService)
        {
            _goodTypeService = goodTypeService;

            InitializeComponent();
        }
    }
}