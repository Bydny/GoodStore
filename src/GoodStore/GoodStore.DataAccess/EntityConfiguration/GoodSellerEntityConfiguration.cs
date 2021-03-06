﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.Domain.Entities;

namespace GoodStore.DataAccess.EntityConfiguration
{
    class GoodSellerEntityConfiguration : EntityTypeConfiguration<GoodSellerEntity>
    {
        public GoodSellerEntityConfiguration()
        {
            this.ToTable("GoodSellers")
                .HasKey(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired();

            this.Property(x => x.Description)
                .IsOptional()
                .HasMaxLength(1000);
        }
    }
}
