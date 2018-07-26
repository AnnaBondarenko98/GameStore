using System.Collections.Generic;
using AutoMapper;
using GameStore.Bll.Interfaces;
using GameStore.Bll.ModelsDto;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;
using NLog;

namespace GameStore.Bll.Services
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PlatformTypeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<PlatformTypeDto> GetAll()
        {
            _logger.Info("Getting all platforms");

            var platforms = _unitOfWork.PlatformTypeGenericRepository.GetAll();

            return _mapper.Map<ICollection<PlatformTypeDto>>(platforms);
        }

        public PlatformTypeDto Get(int id)
        {
            _logger.Info($"Getting platform by id {id}");

            var platform = _unitOfWork.PlatformTypeGenericRepository.Get(id);

            return _mapper.Map<PlatformTypeDto>(platform);
        }

        public void Create(PlatformTypeDto platform)
        {
            _logger.Info($"Creating new platform: name = {platform.Type}");

            _unitOfWork.PlatformTypeGenericRepository.Create(_mapper.Map<PlatformType>(platform));

            _unitOfWork.Commit();
        }

        public void Update(PlatformTypeDto platformTypeDto)
        {
            _logger.Info($"Updating the platform: id = {platformTypeDto.Id}, name = {platformTypeDto.Type}");

            var platform = _mapper.Map<PlatformType>(platformTypeDto);

            _unitOfWork.PlatformTypeGenericRepository.Update(platform);

            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _logger.Info($"Deleting the pletform by id : id = {id}");

            _unitOfWork.PlatformTypeGenericRepository.Delete(id);

            _unitOfWork.Commit();
        }
    }
}
