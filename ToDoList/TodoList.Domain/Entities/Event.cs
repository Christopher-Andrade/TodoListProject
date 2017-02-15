using System.Collections.Generic;

namespace TodoList.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Comment.Comment> Comments { get; set; }

        public City City { get; set; }

        public Province Province { get; set; }
    }
}
