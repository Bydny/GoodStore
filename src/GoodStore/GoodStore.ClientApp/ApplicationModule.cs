using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GoodStore.BussinessLogic.Abstractions.Services;
using GoodStore.BussinessLogic.DTOs;
using GoodStore.BussinessLogic.Implementation.Services;
using GoodStore.DataAccess.Implementation;
using GoodStore.DataAccess.Interfaces;
using Ninject;
using Ninject.Modules;

namespace GoodStore.ClientApp
{
    internal class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            BindMapper();
            BindContext();

            Bind(typeof(IService<,>)).To(typeof(Service<,>));
            Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));

            Bind<IGoodTypeService>().To<GoodTypeService>();
        }

        private void BindContext()
        {
            var connectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["GoodStore"].ConnectionString;

            Bind(typeof(DbContext))
                .ToMethod(_ => new GoodStoreContextFactory().Create());
        }

        private void BindMapper()
        {
            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                var profiles = GetAssemblyProfiles<GoodDto>();
                cfg.AddProfiles(profiles);
            });

            return config;
        }

        private IEnumerable<Profile> GetAssemblyProfiles<T>()
        {
            return typeof(T).Assembly.GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x))
                .Select(x => Activator.CreateInstance(x) as Profile)
                .ToList();
        }
    }
}
