using System;
using System.Collections.Generic;
using TodoList.Domain.Entities;

namespace TodoList.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();

        IEnumerable<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0);

        void AddEvent(Event ev);
    }
}
