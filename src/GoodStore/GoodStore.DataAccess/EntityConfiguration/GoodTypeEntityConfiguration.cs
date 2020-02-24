using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Entities;

namespace GoodStore.DataAccess.EntityConfiguration
{
    class GoodTypeEntityConfiguration : EntityTypeConfiguration<GoodTypeEntity>
    {
        public GoodTypeEntityConfiguration()
        {
            this.ToTable("GoodTypes")
                .HasKey(x => x.Id);
            
            this.Property(x => x.Name)
                .IsRequired();
        }
    }
}
