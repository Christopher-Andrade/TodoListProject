using System;
using System.Collections.Generic;
using TodoList.Common.Repository;
using TodoList.Domain;

namespace TodoList.Services.SqlRepository
{
    public class SqlEventRepo : IEventRepo
    {
        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEventsByProvince()
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEventsByCity()
        {
            throw new NotImplementedException();
        }

        public void AddEvent(Event ev)
        {
            throw new NotImplementedException();
        }
    }
}
