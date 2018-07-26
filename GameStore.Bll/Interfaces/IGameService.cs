using System.Collections.Generic;
using GameStore.Bll.Infrastructure;
using GameStore.Bll.ModelsDto;

namespace GameStore.Bll.Interfaces
{
    public interface IGameService
    {
        IEnumerable<GameDto> GetAll();

        GameDto Get(int id);

        OptionalDetails Create(CreatingGameDto game);

        OptionalDetails Update(CreatingGameDto game);

        OptionalDetails Delete(int id);

        OptionalDetails AddComment(int id, CommentDto comment);

        ICollection<GameDto> GetByKey(string key);

        IEnumerable<CommentDto> GetAllComments(string gameKey);

        IEnumerable<GameDto> GetGamesByGenre(GenreDto genre);

        IEnumerable<GameDto> GetGamesByPlatformTypes(IEnumerable<PlatformTypeDto> types);

    }
}
