using AutoMapper;
using GameStore.Bll.Infrastructure.Mapper;

namespace GameStore.Infrastructure.Mapper
{
    public class MapperInitialize
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ForAllMaps((map, expression) => map.PreserveReferences = true);

                cfg.AddProfile(new DomainModelToDtoModel());
                cfg.AddProfile(new DtoModelToDomainModel());
            });

            return config;
        }
    }
}