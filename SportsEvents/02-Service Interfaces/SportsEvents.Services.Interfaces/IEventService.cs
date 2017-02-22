using System;
using System.Collections.Generic;
using SportsEvents.Domain.Entities;

namespace SportsEvents.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();

        IEnumerable<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0);

        void AddEvent(Event ev);
    }
}
