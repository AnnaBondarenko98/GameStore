using AutoMapper;
using GameStore.Bll.ModelsDto;
using GameStore.Web.Models;

namespace GameStore.Web.Infrastructure.Mapper
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