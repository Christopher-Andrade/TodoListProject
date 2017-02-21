using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Services.Interfaces;

namespace TodoList.Services
{
    public class CommentService: ICommentService
    {
        private readonly IGenericRepository<Comment> _commentRepo;

        public CommentService(IGenericRepository<Comment> commentRepo)
        {
            _commentRepo = commentRepo;
        }
        public ICollection<Comment> GetCommentsForParent(string parentIdentifier, CommentType type)
        {
            return _commentRepo.GetByPredicate(x => x.CommentType == type && x.ParentIdentifier == parentIdentifier).ToList();
        }

        public void AddComment(Comment comment)
        {
            if (comment.CommentType == CommentType.Unknown)
                throw new ArgumentException("Comment type cannot be unknown");

            if (string.IsNullOrEmpty(comment.ParentIdentifier))
                throw new ArgumentNullException();

            _commentRepo.Add(comment);
        }
    }
}