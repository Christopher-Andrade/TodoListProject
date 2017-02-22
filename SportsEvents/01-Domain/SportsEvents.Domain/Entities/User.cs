using System.ComponentModel.DataAnnotations;

namespace SportsEvents.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


    }
}
