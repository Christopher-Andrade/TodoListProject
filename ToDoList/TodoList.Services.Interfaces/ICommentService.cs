using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Services.Interfaces
{
    public interface ICommentService
    {
        ICollection<Comment> GetCommentsForParent(string parentIdentifier, CommentType type);

        void AddComment(Comment comment);
    }
}
