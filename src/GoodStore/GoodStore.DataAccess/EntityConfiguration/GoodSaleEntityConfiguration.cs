using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Entities;

namespace GoodStore.DataAccess.EntityConfiguration
{
    class GoodSaleEntityConfiguration : EntityTypeConfiguration<GoodSaleEntity>
    {
        public GoodSaleEntityConfiguration()
        {
            this.ToTable("GoodSales")
                .HasKey(x => x.Id);

            this.Property(x => x.Date)
                .IsRequired();

            this.Property(x => x.GoodAmount)
                .IsRequired();

            this.Property(x => x.TotalPrice)
                .IsRequired();

            this.HasRequired(s => s.Good)
                .WithMany(g => g.GoodSales);

            this.HasRequired(s => s.Client)
                .WithMany(c => c.GoodSales);
        }
    }
}
