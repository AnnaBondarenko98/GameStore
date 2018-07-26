using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameStore.Bll.Infrastructure;
using GameStore.Bll.Interfaces;
using GameStore.Bll.ModelsDto;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;
using NLog;

namespace GameStore.Bll.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<GameDto> GetAll()
        {
            var games = _unitOfWork.GameGenericRepository.GetAll();

            var gamesDto = _mapper.Map<ICollection<GameDto>>(games);

            _logger.Info("Geted all Games");

            return gamesDto;
        }

        public GameDto Get(int id)
        {
            var game = _unitOfWork.GameGenericRepository.Get(id);

            var gameDto = _mapper.Map<GameDto>(game);

            _logger.Info($"Geted one game by id {id}");

            return gameDto;
        }

        public OptionalDetails Create(CreatingGameDto gameDto)
        {
            int gameExist = _unitOfWork.GameGenericRepository.Find(g => g.Key == gameDto.Key).Count();

            if (gameExist > 0)
            {
                return new OptionalDetails("The game with this key already exist", false);
            }
            var ganres = _unitOfWork.GenreGenericRepository.Find(g => gameDto.GenresIds.Contains(g.Id)).ToList();
            var platforms = _unitOfWork.PlatformTypeGenericRepository.Find(p => gameDto.PlatformTypesIds.Contains(p.Id)).ToList();

            var game = _mapper.Map<Game>(gameDto);

            game.Genres = ganres;
            game.PlatformTypes = platforms;

            _unitOfWork.GameGenericRepository.Create(game);
            _unitOfWork.Commit();

            _logger.Info($"Created the game: name = {gameDto.Name}, key = {gameDto.Key}, descriotion = {gameDto.Description} ");

            return new OptionalDetails("Game was created", true);
        }

        public OptionalDetails Update(CreatingGameDto gameDto)
        {
            var ganres = _unitOfWork.GenreGenericRepository.Find(g => gameDto.GenresIds.Contains(g.Id)).ToList();
            var platforms = _unitOfWork.PlatformTypeGenericRepository.Find(p => gameDto.PlatformTypesIds.Contains(p.Id)).ToList();

            var game = _unitOfWork.GameGenericRepository.Find(g => g.Id == gameDto.Id).First();

            game.Genres.Clear();
            game.PlatformTypes.Clear();

            game.Genres = ganres;
            game.PlatformTypes = platforms;

            _unitOfWork.GameGenericRepository.Update(game);
            _unitOfWork.Commit();

            _logger.Info($"Updated existing game: id = {gameDto.Id}, name = {gameDto.Name}, key = {gameDto.Key}, description = {gameDto.Description}");

            return new OptionalDetails("The game was successfully updated", true);

        }

        public OptionalDetails Delete(int id)
        {
            _unitOfWork.GameGenericRepository.Delete(id);
            _unitOfWork.Commit();

            _logger.Info($"Deleted the game by id {id}");

            return new OptionalDetails("The game was successfully deleted", true);
        }

        public OptionalDetails AddComment(int id, CommentDto comment)
        {

            var game = _unitOfWork.GameGenericRepository.Get(id);

            if (comment == null || game == null)
            {
                throw new ArgumentNullException();
            }

            game.Comments.Add(_mapper.Map<Comment>(comment));

            _unitOfWork.GameGenericRepository.Update(game);
            _unitOfWork.Commit();

            _logger.Info($"Added the comment to the game: gameid = {id}, comment name = {comment.Name}, comment body = {comment.Body} ");

            return new OptionalDetails("The comment was successfully added to game", true);
        }

        public ICollection<GameDto> GetByKey(string key)
        {
            var games = _unitOfWork.GameGenericRepository.Find(g => g.Key == key).ToList();

            var gamesDto = _mapper.Map<ICollection<GameDto>>(games);

            _logger.Info($"Geted the games by key {key}");

            return gamesDto;
        }

        public IEnumerable<CommentDto> GetAllComments(string gameKey)
        {
            var comments = _unitOfWork.GameGenericRepository.Find(t => t.Key == gameKey).First().Comments;

            var commentsDtos = _mapper.Map<ICollection<CommentDto>>(comments);

            _logger.Info($"Geted All Commets by game key {gameKey}");

            return commentsDtos;
        }

        public IEnumerable<GameDto> GetGamesByGenre(GenreDto genreDto)
        {
            if (genreDto == null)
            {
                throw new ArgumentNullException();
            }

            var genre = _mapper.Map<Genre>(genreDto);

            var games = _unitOfWork.GameGenericRepository.Find(g => g.Genres.Contains(genre));

            var gameDtos = _mapper.Map<ICollection<GameDto>>(games);

            _logger.Info($"Geted games by convrete genre: genre name = {genreDto.Name}, parent genre = {genreDto.ParentGenre.Name}");

            return gameDtos;
        }

        public IEnumerable<GameDto> GetGamesByPlatformTypes(IEnumerable<PlatformTypeDto> typesDto)
        {
            if (typesDto == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<PlatformType> types = _mapper.Map<ICollection<PlatformType>>(typesDto);

            var games = _unitOfWork.GameGenericRepository.Find(g => g.PlatformTypes.Any(p => types.Contains(p)));

            var gamesDto = _mapper.Map<IEnumerable<GameDto>>(games);

            _logger.Info($"Geted Games by platform types");

            return gamesDto;
        }
    }
}
