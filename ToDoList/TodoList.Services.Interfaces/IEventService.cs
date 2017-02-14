using System;
using System.Collections.Generic;
using TodoList.Domain.Entities;
using TodoList.Domain.Entities.Comment;

namespace TodoList.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();

        IEnumerable<Event> GetEventsByProvince(int provinceId);

        IEnumerable<Event> GetEventsByCity(int cityId);

        IEnumerable<Comment> GetCommentsForEvent(int eventId);
    }
}
