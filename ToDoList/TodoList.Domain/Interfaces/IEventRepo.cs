using System.Collections.Generic;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces
{
    public interface IEventRepo
    {
        List<Event> GetAllEvents();

        List<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0);

        void AddEvent(Event ev);
    }
}
