using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodStore.DataAccess.EntityConfiguration;
using GoodStore.Domain.Entities;

namespace GoodStore.DataAccess.Implementation
{
    public class GoodStoreContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<GoodEntity> Goods { get; set; }
        public DbSet<GoodSaleEntity> GoodSales { get; set; }
        public DbSet<GoodSellerEntity> GoodSellers { get; set; }
        public DbSet<GoodTypeEntity> GoodTypes { get; set; }
        public DbSet<StoreUserEntity> StoreUsers { get; set; }

        public GoodStoreContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientEntityConfiguration());
            modelBuilder.Configurations.Add(new GoodEntityConfiguration());
            modelBuilder.Configurations.Add(new GoodSaleEntityConfiguration());
            modelBuilder.Configurations.Add(new GoodSellerEntityConfiguration());
            modelBuilder.Configurations.Add(new GoodTypeEntityConfiguration());
            modelBuilder.Configurations.Add(new StoreUserEntityConfiguration());
        }
    }
}
