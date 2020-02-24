using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodStore.DataAccess.Implementation
{
    public class GoodStoreContextFactory : IDbContextFactory<GoodStoreContext>
    {
        public GoodStoreContext Create()
        {
            return new GoodStoreContext("Server=(localdb)\\mssqllocaldb;Database=GoodStore;Trusted_Connection=True;");
        }
    }
}
