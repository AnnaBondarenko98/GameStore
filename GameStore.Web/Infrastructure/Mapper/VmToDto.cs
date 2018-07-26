using AutoMapper;
using GameStore.Bll.ModelsDto;
using GameStore.Models;

namespace GameStore.Infrastructure.Mapper
{
    public class VmToDto : Profile
    {
        public VmToDto()
        {
            CreateMap<CommentVm, CommentDto>();
            CreateMap<GameVm, GameDto>();
            CreateMap<GenreVm, GenreDto>();
            CreateMap<PlatformTypeVm, PlatformTypeDto>();
        }
    }
}