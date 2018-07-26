using AutoMapper;
using GameStore.Bll.ModelsDto;
using GameStore.Dal.Models;

namespace GameStore.Bll.Infrastructure.Mapper
{
    public class DtoModelToDomainModel : Profile
    {
        public DtoModelToDomainModel()
        {
            CreateMap<CommentDto, Comment>();
            CreateMap<GameDto, Game>();
            CreateMap<CreatingGameDto, Game>().ForMember(d => d.Genres, o => o.Ignore()).ForMember(d => d.PlatformTypes, o => o.Ignore());
            CreateMap<GenreDto, Genre>();
            CreateMap<PlatformTypeDto, PlatformType>();
        }
    }
}