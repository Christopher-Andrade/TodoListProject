using System.Collections.Generic;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces
{
    public interface IEventRepo
    {
        List<Event> GetAllEvents();

        List<Event> GetEventsByProvince();

        List<Event> GetEventsByCity();

        void AddEvent(Event ev);
    }
}
