using GameStore.Dal.Models;

namespace GameStore.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Game> GameGenericRepository { get; }

        IGenericRepository<Comment> CommentGenericRepository { get; }

        IGenericRepository<Genre> GenreGenericRepository { get; }

        IGenericRepository<PlatformType> PlatformTypeGenericRepository { get; }

        void Commit();
    }
}
