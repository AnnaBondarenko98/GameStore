using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GameStore.Bll.Infrastructure.Autofac;
using GameStore.Web;

namespace GameStore.Infrastructure.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new ServiceModule("GameStoreContext"));
            builder.RegisterModule(new WebModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}