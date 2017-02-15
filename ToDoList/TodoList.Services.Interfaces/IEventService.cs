using System;
using System.Collections.Generic;
using TodoList.Domain.Entities;
using TodoList.Domain.Entities.Comment;

namespace TodoList.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();

        IEnumerable<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0);

        IEnumerable<Comment> GetCommentsForEvent(int eventId);

        void AddEvent(Event ev);
    }
}
