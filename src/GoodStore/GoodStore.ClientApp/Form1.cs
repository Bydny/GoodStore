using System;
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
using GoodStore.Domain.Entities;

namespace GoodStore.ClientApp
{
    public partial class Form1 : Form
    {
        private readonly IService<GoodTypeDto, GoodTypeEntity> _goodTypeService;

        public Form1(IService<GoodTypeDto, GoodTypeEntity> goodTypeService)
        {
            _goodTypeService = goodTypeService;

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var added = await _goodTypeService.AddAsync(new GoodTypeDto() { Name = textBox1.Text});

            MessageBox.Show($"Added {added}");
        }
    }
}
