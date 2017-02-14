using System;

namespace TodoList.Domain.Entities.Comment
{
    public abstract class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FullComment { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }

        public string CommentParentIdentifier { get; set; }
    }
}
