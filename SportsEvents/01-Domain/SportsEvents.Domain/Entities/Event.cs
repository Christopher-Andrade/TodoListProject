using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsEvents.Domain.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        public virtual City City { get; set; }


        public virtual Province Province { get; set; }
    }
}
