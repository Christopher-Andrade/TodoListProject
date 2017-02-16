﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Entities
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
