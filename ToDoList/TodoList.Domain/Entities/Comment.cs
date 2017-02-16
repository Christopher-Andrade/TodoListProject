using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Entities.Comment
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string FullComment { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }

        public string CommentParentIdentifier { get; set; }
    }
}
