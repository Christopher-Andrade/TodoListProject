using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Entities;
using TodoList.Domain.Entities.Comment;
using TodoList.Domain.Interfaces;
using TodoList.Services.Interfaces;

namespace TodoList.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepo _eventRepo;
        private readonly ICommentRepo _commentRepo;

        private EventService()
        {
            
        }



        public EventService(IEventRepo eventRepo, ICommentRepo commentRepo)
        {
            _eventRepo = eventRepo;
            _commentRepo = commentRepo;
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepo.GetAllEvents();
        }

        public IEnumerable<Comment> GetCommentsForEvent(int eventId)
        {
            return _commentRepo.GetCommentsByParentIdentifier(eventId.ToString());
        }

        public void AddEvent(Event ev)
        {
            _eventRepo.AddEvent(ev);

        }

        public IEnumerable<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0)
        {
            return _eventRepo.GetEventsByLocale(provinceId, cityId);
        }
    }
}
