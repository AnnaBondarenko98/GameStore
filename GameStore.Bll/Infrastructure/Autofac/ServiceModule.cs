using Autofac;
using GameStore.Dal.Context;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Repository;
using NLog;

namespace GameStore.Bll.Infrastructure.Autofac
{
    public class ServiceModule : Module
    {
        private readonly string _connection;

        public ServiceModule(string connection)
        {
            _connection = connection;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameStoreContext>().As<IGameStoreContext>()
                .WithParameter("connection", _connection).InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.Register(logger => LogManager.GetLogger("*")).As<ILogger>();
        }
    }
}
