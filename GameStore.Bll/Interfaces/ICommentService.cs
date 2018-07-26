using System.Collections.Generic;
using GameStore.Bll.Infrastructure;
using GameStore.Bll.ModelsDto;

namespace GameStore.Bll.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetAll();

        CommentDto Get(int id);

        OptionalDetails Create(CommentDto comment);

        OptionalDetails Update(CommentDto comment);

        OptionalDetails Delete(int id);
    }
}