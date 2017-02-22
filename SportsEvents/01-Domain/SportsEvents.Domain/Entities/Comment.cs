using System;
using System.ComponentModel.DataAnnotations;

namespace SportsEvents.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string FullComment { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }

        public string ParentIdentifier { get; set; }

       public virtual CommentType CommentType { get; set; }
    }

    public enum CommentType
    {
        Unknown = 0,

        Article = 1,

        Event = 2,

        NotSpecified = 3
    }
}
