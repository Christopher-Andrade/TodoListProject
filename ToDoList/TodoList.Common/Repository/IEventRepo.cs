﻿using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain;

namespace TodoList.Common.Repository
{
    public interface IEventRepo
    {
        List<Event> GetAllEvents();

        List<Event> GetEventsByProvince();

        List<Event> GetEventsByCity();

        void AddEvent(Event ev);
    }
}
