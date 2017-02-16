using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
