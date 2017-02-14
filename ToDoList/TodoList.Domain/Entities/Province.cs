using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
