using AutoMapper;
using GameStore.Bll.ModelsDto;
using GameStore.Models;

namespace GameStore.Infrastructure.Mapper
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