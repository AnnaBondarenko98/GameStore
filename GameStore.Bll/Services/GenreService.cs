using System.Collections.Generic;
using AutoMapper;
using GameStore.Bll.Interfaces;
using GameStore.Bll.ModelsDto;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;
using NLog;

namespace GameStore.Bll.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<GenreDto> GetAll()
        {
            _logger.Info("Getting all genres");

            var genres = _unitOfWork.GenreGenericRepository.GetAll();

            return _mapper.Map<ICollection<GenreDto>>(genres);
        }

        public GenreDto Get(int id)
        {
            _logger.Info($"Getting genre by id {id}");

            var genre = _unitOfWork.GenreGenericRepository.Get(id);

            return _mapper.Map<GenreDto>(genre);
        }

        public void Create(GenreDto genreDto)
        {
            _logger.Info($"Creating new genre: name = {genreDto.Name}, body = {genreDto.ParentGenre.Name}");

            _unitOfWork.GenreGenericRepository.Create(_mapper.Map<Genre>(genreDto));

            _unitOfWork.Commit();
        }

        public void Update(GenreDto genreDto)
        {
            _logger.Info($"Updating the genre: id = {genreDto.Id}, name = {genreDto.Name}");

            var genre = _mapper.Map<Genre>(genreDto);

            _unitOfWork.GenreGenericRepository.Update(genre);

            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _logger.Info($"Deleting the genre: id = {id}");

            _unitOfWork.GenreGenericRepository.Delete(id);

            _unitOfWork.Commit();
        }
    }
}
