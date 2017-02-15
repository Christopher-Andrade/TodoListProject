using System.Collections.Generic;
using TodoList.Domain.Entities.Comment;
using TodoList.Domain.Interfaces;

namespace TodoList.Infrastructure.Data.SqlRepository
{
    public class CommentRepo: ICommentRepo
    {
        public IEnumerable<Comment> GetCommentsByParentIdentifier(string identifier)
        {
            throw new System.NotImplementedException();
        }
    }
}
