using System.Collections.Generic;
using AutoMapper;
using GameStore.Bll.Infrastructure;
using GameStore.Bll.Interfaces;
using GameStore.Bll.ModelsDto;
using GameStore.Dal.Interfaces;
using GameStore.Dal.Models;
using NLog;

namespace GameStore.Bll.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<CommentDto> GetAll()
        {
            _logger.Info("Getting all comments");

            var comments = _unitOfWork.CommentGenericRepository.GetAll();

            var commentsDto = _mapper.Map<ICollection<CommentDto>>(comments);

            return commentsDto;
        }

        public CommentDto Get(int id)
        {
            _logger.Info($"Getting comment by id {id}");

            var comment = _unitOfWork.CommentGenericRepository.Get(id);

            var commentDto = _mapper.Map<CommentDto>(comment);

            return commentDto;
        }

        public OptionalDetails Create(CommentDto comment)
        {
            _logger.Info($"Creating new comment: name = {comment.Name}, body = {comment.Body}");

            _unitOfWork.CommentGenericRepository.Create(_mapper.Map<Comment>(comment));

            _unitOfWork.Commit();

            return new OptionalDetails("Comment was created", true);
        }

        public OptionalDetails Update(CommentDto commentDto)
        {
            _logger.Info($"Updating the comment: id = {commentDto.Id}, name = {commentDto.Name},body = {commentDto.Body}");

            var comment = _mapper.Map<Comment>(commentDto);

            _unitOfWork.CommentGenericRepository.Update(comment);

            _unitOfWork.Commit();

            return new OptionalDetails("Comment was updated", true);
        }

        public OptionalDetails Delete(int id)
        {
            _logger.Info($"Deleting the comment: id = {id}");

            _unitOfWork.CommentGenericRepository.Delete(id);

            _unitOfWork.Commit();

            return new OptionalDetails("Comment was deleted", true);
        }
    }
}
