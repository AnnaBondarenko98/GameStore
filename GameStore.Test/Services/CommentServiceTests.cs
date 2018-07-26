using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
     public class CommentServiceTests
    {
        private readonly ICommentService _sut;
        private readonly Mock<IUnitOfWork> _unitOfWorMock;

        public CommentServiceTests()
        {
            var mapper = MapperInitialize.InitializeAutoMapper().CreateMapper();

            var logger = new Mock<ILogger>();
            _unitOfWorMock = new Mock<IUnitOfWork>();

            _sut = new CommentService(_unitOfWorMock.Object, mapper, logger.Object);
        }

        [Fact]
        public void GetAll_ExistAllComments_ReturnsCommentList()
        {
            var comments = new List<Comment>() { new Comment() };

            _unitOfWorMock.Setup(uof => uof.CommentGenericRepository.GetAll()).Returns(comments);

            var result = _sut.GetAll();

            Assert.Equal(comments.Count, result.Count());
        }

        [Fact]
        public void Get_ExistingId_ReturnsCommentById()
        {
            int id = 1;
            var comment = new Comment() { Id = id, Name = "Comment", Body = "Body"};

            _unitOfWorMock.Setup(uof => uof.CommentGenericRepository.Get(id)).Returns(comment);

            var result = _sut.Get(id);

            Assert.Equal(id, result.Id);
        }

        [Fact]
        public void Create_NewComment_ReturnsTrue()
        {
            int id = 1;
            var comment = new CommentDto() { Id = id, Name = "Comment", Body = "Body" };

            _unitOfWorMock.Setup(uof => uof.CommentGenericRepository.Create(new Comment()));
            var result = _sut.Create(comment);

            Assert.True(result.Succeed);
        }


    }
}
