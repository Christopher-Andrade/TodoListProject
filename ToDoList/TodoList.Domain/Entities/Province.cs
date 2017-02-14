using System.Collections.Generic;

namespace TodoList.Domain.Entities
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
