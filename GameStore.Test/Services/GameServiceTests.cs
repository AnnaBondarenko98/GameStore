using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GameStore.Bll.Interfaces;
using GameStore.Bll.ModelsDto;
using GameStore.Bll.Services;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;
using GameStore.Infrastructure.Mapper;
using Moq;
using NLog;
using Xunit;

namespace GameStore.Test.Services
{
    public class GameServiceTests
    {
        private readonly IGameService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorMock;

        public GameServiceTests()
        {
            var mapper = MapperInitialize.InitializeAutoMapper().CreateMapper();

            var logger = new Mock<ILogger>();
            _unitOfWorMock = new Mock<IUnitOfWork>();

            _sut = new GameService(_unitOfWorMock.Object, mapper, logger.Object);
        }

        [Fact]
        public void GetAll_ExistAllGames_ReturnsGameList()
        {
            var games = new List<Game>() { new Game() };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.GetAll()).Returns(games);

            var result = _sut.GetAll();

            Assert.Equal(games.Count, result.Count());
        }

        [Fact]
        public void Get_ExistingId_ReturnsGameById()
        {
            int id = 1;
            var game = new Game() { Id = id };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Get(id)).Returns(game);

            var result = _sut.Get(id);

            Assert.Equal(id, result.Id);
        }

        [Fact]
        public void Create_NewGame_ReturnsFalse()
        {
            string key = "1qw2";
            var game = new CreatingGameDto() { Key = key };
            var games = new List<Game>() { new Game() { Key = key } };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Find(It.IsAny<Expression<Func<Game, bool>>>())).Returns(games);

            var result = _sut.Create(game);

            Assert.False(result.Succeed);
        }

        [Fact]
        public void Create_NewGame_ReturnsTrue()
        {
            string key = "1qw2";
            var game = new CreatingGameDto() { Key = key };
            var games = new List<Game>();

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Find(It.IsAny<Expression<Func<Game, bool>>>())).Returns(games);
            _unitOfWorMock.Setup(uof => uof.GenreGenericRepository.Find(It.IsAny<Expression<Func<Genre, bool>>>())).Returns(new List<Genre>());
            _unitOfWorMock.Setup(uof => uof.PlatformTypeGenericRepository.Find(It.IsAny<Expression<Func<PlatformType, bool>>>())).Returns(new List<PlatformType>());

            var result = _sut.Create(game);

            Assert.True(result.Succeed);
        }

        [Fact]
        public void Update_ExistingGame_UpdatingTheKey()
        {
            string key = "1qw2";
            string newKey = "new111";
            var game = new CreatingGameDto() { Id = 1, Key = key };
            var games = new List<Game>() { new Game() { Id = 1, Key = newKey, Genres = new List<Genre>(), PlatformTypes = new List<PlatformType>() } };

            _unitOfWorMock.Setup(uof => uof.GenreGenericRepository.Find(It.IsAny<Expression<Func<Genre, bool>>>())).Returns(new List<Genre>());
            _unitOfWorMock.Setup(uof => uof.PlatformTypeGenericRepository.Find(It.IsAny<Expression<Func<PlatformType, bool>>>())).Returns(new List<PlatformType>());
            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Find(It.IsAny<Expression<Func<Game, bool>>>())).Returns(games);

            var result = _sut.Update(game);
            Assert.True(result.Succeed);
        }

        [Fact]
        public void Delete_ExistingGameById_ReturnsTrue()
        {
            int id = 1;
            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Delete(id));

            var result = _sut.Delete(id);

            Assert.True(result.Succeed);
        }

        [Fact]
        public void AddComment_ExistingGameIdAndCommentDto_ReturnsTrue()
        {
            int id = 1;
            var commentDto = new CommentDto();
            var game = new Game() { Id = id, Comments = new List<Comment>() };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Get(id)).Returns(game);

            var result = _sut.Get(id);
            var addCommentResult = _sut.AddComment(id, commentDto);

            Assert.True(addCommentResult.Succeed);
        }

        [Fact]
        public void AddComment_ExistingGameIdAndCommentDto_ThrowsArgumentNullExceptionCausedGame()
        {
            int id = 1;
            var commentDto = new CommentDto();
            Game game = null;

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Get(id)).Returns(game);

            var result = _sut.Get(id);

            Assert.Throws<ArgumentNullException>(() => _sut.AddComment(id, commentDto));
        }

        [Fact]
        public void AddComment_ExistingGameIdAndCommentDto_ThrowsArgumentNullExceptionCausedComment()
        {
            int id = 1;
            CommentDto commentDto = null;
            Game game = new Game() { Id = id, Comments = new List<Comment>() }; ;

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Get(id)).Returns(game);

            var result = _sut.Get(id);

            Assert.Throws<ArgumentNullException>(() => _sut.AddComment(id, commentDto));
        }

        [Fact]
        public void GetGame_ExictingGameKey_ReturnsGameList()
        {
            var key = "key11";
            var games = new List<Game>() { new Game() };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Find(It.IsAny<Expression<Func<Game, bool>>>())).Returns(games);

            var result = _sut.GetByKey(key);

            Assert.Equal(games.Count, result.Count);

        }

        [Fact]
        public void GetAllComments_ExictingGameKey_ReturnsGameList()
        {
            var key = "key11";
            var games = new List<Game>() { new Game() { Comments = new List<Comment>() } };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Find(It.IsAny<Expression<Func<Game, bool>>>())).Returns(games);

            var result = _sut.GetAllComments(key);

            Assert.Equal(games.First().Comments.Count, result.Count());

        }

        [Fact]
        public void GetGamesByGenre_ExictingGenreDto_ReturnsGameList()
        {
            var genre = new GenreDto() { Id = 1, Name = "First", ParentGenre = new GenreDto() };
            var games = new List<Game>() { new Game() { Comments = new List<Comment>(), Genres = new List<Genre>() { new Genre() { Id = 1, Name = "First", ParentGenre = new Genre() } } } };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Find(It.IsAny<Expression<Func<Game, bool>>>()))
                .Returns(games);

            var result = _sut.GetGamesByGenre(genre);

            Assert.Equal(result.Count(), games.Count);
        }

        [Fact]
        public void GetGamesByGenre_ExictingGenreDto_ThrowsNullArgumentException()
        {
            GenreDto genre = null;

            Assert.Throws<ArgumentNullException>(() => _sut.GetGamesByGenre(genre));
        }

        [Fact]
        public void GetGamesByPlatformTypes_ExictingPlatformTypes_ThrowsNullArgumentException()
        {
            List<PlatformTypeDto> types = null;

            Assert.Throws<ArgumentNullException>(() => _sut.GetGamesByPlatformTypes(types));
        }

        [Fact]
        public void GetGamesByPlatformTypes_ExictingPlatformTypes_()
        {
            var types = new List<PlatformTypeDto>();
            var games = new List<Game>() { new Game() { Comments = new List<Comment>(), Genres = new List<Genre>() { new Genre() { Id = 1, Name = "First", ParentGenre = new Genre() } } } };

            _unitOfWorMock.Setup(uof => uof.GameGenericRepository.Find(It.IsAny<Expression<Func<Game, bool>>>()))
                .Returns(games);

            var result = _sut.GetGamesByPlatformTypes(types);

            Assert.Equal(games.Count,result.Count());
        }
    }
}
