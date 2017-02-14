using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain
{
    public abstract class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FullComment { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }
    }
}
