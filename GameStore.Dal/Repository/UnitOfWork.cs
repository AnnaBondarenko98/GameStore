using System;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;

namespace GameStore.Dal.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IGameStoreContext _db;

        //todo naming
        private readonly Lazy<GenericRepository<Comment>> _commentGenericRepository;
        private readonly Lazy<GenericRepository<Game>> _gameGenericRepository;
        private readonly Lazy<GenericRepository<Genre>> _genreRepos;
        private readonly Lazy<GenericRepository<PlatformType>> _platformTypeRepos;

        public UnitOfWork(IGameStoreContext db)
        {
            _db = db;
            _commentGenericRepository = new Lazy<GenericRepository<Comment>>(
                () => new GenericRepository<Comment>(_db));
            _gameGenericRepository = new Lazy<GenericRepository<Game>>(
                () => new GenericRepository<Game>(_db));
            _genreRepos = new Lazy<GenericRepository<Genre>>(
                () => new GenericRepository<Genre>(_db));
            _platformTypeRepos = new Lazy<GenericRepository<PlatformType>>(
                () => new GenericRepository<PlatformType>(_db));
        }

        public IGenericRepository<Comment> CommentGenericRepository => _commentGenericRepository.Value;

        public IGenericRepository<Game> GameGenericRepository => _gameGenericRepository.Value;

        public IGenericRepository<Genre> GenreGenericRepository => _genreRepos.Value;

        public IGenericRepository<PlatformType> PlatformTypeGenericRepository => _platformTypeRepos.Value;

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
