﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvents.Domain.Entities;

namespace SportsEvents.Services.Interfaces
{
    public interface ICommentService
    {
        ICollection<Comment> GetCommentsForParent(string parentIdentifier, CommentType type);

        void AddComment(Comment comment);
    }
}
