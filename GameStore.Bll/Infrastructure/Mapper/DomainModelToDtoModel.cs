using AutoMapper;
using GameStore.Bll.ModelsDto;
using GameStore.Dal.Models;

namespace GameStore.Bll.Infrastructure.Mapper
{
    public class DomainModelToDtoModel : Profile
    {
        public DomainModelToDtoModel()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<Game, GameDto>();
            CreateMap<Game, CreatingGameDto>().ForMember(d => d.GenresIds, o => o.Ignore()).ForMember(d => d.PlatformTypesIds, o => o.Ignore());
            CreateMap<Genre, GenreDto>();
            CreateMap<PlatformType, PlatformTypeDto>();
        }
    }
}