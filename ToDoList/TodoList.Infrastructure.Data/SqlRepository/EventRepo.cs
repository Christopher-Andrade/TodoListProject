using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Infrastructure.Data.SqlRepository
{



    public class EventRepo : GenericRepository<EventContext, Event>
    {
        public List<Event> GetAllEvents()
        {
            return GetAll().ToList();
        }


        public void AddEvent(Event ev)
        {
            Add(ev);
        }

        public List<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0)
        {
            IQueryable<Event> query = new EventContext().Events;
            if (provinceId > 0)
            {
                query = query.Where(x => x.Province.Id == provinceId);
            }
            if (cityId > 0)
            {
                query = query.Where(x => x.City.Id == cityId);
            }
            Predicate<Event> p = new Predicate<Event>(true);


            var res2 = GetByPredicate();


        }
    }
}
