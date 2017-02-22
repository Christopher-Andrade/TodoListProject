using System.ComponentModel.DataAnnotations;

namespace SportsEvents.Domain.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
