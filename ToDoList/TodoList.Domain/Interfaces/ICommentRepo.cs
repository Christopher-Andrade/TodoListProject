using System.Collections;
using System.Collections.Generic;
using TodoList.Domain.Entities.Comment;

namespace TodoList.Domain.Interfaces
{
    public interface ICommentRepo
    {
        IEnumerable<Comment> GetCommentsByParentIdentifier(string identifier);

    }
}
