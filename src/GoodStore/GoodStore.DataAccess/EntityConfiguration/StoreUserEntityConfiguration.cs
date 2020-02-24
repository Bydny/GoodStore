using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Entities;

namespace GoodStore.DataAccess.EntityConfiguration
{
    class StoreUserEntityConfiguration : EntityTypeConfiguration<StoreUserEntity>
    {
        public StoreUserEntityConfiguration()
        {
            this.ToTable("StoreUsers")
                .HasKey(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired();

            this.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(x => x.Role)
                .IsRequired();
        }
    }
}
