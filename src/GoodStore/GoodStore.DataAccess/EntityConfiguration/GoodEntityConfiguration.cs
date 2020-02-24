using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Entities;

namespace GoodStore.DataAccess.EntityConfiguration
{
    class GoodEntityConfiguration : EntityTypeConfiguration<GoodEntity>
    {
        public GoodEntityConfiguration()
        {
            this.ToTable("Goods")
                .HasKey(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired();

            this.Property(x => x.Amount)
                .IsRequired();

            this.Property(x => x.Price)
                .IsRequired();

            this.Property(x => x.IncomingDate)
                .IsRequired();

            this.Property(x => x.Description)
                .IsOptional()
                .HasMaxLength(1000);

            this.HasRequired(g => g.GoodType)
                .WithMany(t => t.Goods);

            this.HasRequired(g => g.GoodSeller)
                .WithMany(s => s.Goods);

            this.HasRequired(g => g.User)
                .WithMany(u => u.Goods);
        }
    }
}
