﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Entities
{
    public class EventComment : Comment
    {
            public int EventId { get; set; }

        public EventComment(): base()
        {

        }

    }
}