using Autofac;
using GameStore.Bll.Interfaces;
using GameStore.Bll.Services;
using GameStore.Infrastructure.Mapper;

namespace GameStore.Infrastructure.Autofac
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<GameService>().As<IGameService>();
            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<PlatformTypeService>().As<IPlatformTypeService>();

            var mapper = MapperInitialize.InitializeAutoMapper().CreateMapper();

            builder.RegisterInstance(mapper);
        }
    }
}