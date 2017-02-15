using System;
using System.Collections.Generic;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Infrastructure.Data.SqlRepository
{
    public class EventRepo : IEventRepo
    {
        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }


        public void AddEvent(Event ev)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0)
        {
            throw new NotImplementedException();
        }
    }
}
