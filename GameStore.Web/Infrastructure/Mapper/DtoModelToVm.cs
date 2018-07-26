using AutoMapper;
using GameStore.Bll.ModelsDto;
using GameStore.Web.Models;

namespace GameStore.Web.Infrastructure.Mapper
{
    public class DtoModelToVm : Profile
    {
        public DtoModelToVm()
        {
            CreateMap<CommentDto, CommentVm>();
            CreateMap<GameDto, GameVm>();
            CreateMap<GenreDto, GenreVm>();
            CreateMap<PlatformTypeDto, PlatformTypeVm>();
        }
    }
}