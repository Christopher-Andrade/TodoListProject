//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using TodoList.Domain.Entities;
//using TodoList.Domain.Interfaces;
//using TodoList.Infrastructure.Data.Context;

//namespace TodoList.Infrastructure.Data.SqlRepository
//{
//    public abstract class EventRepoBase : GenericRepository<EventContext, Event>
//    {
//       public virtual List<Event> GetAllEvents();


//    }
//    public class EventRepo : EventRepoBase
//    {
//        public List<Event> GetAllEvents()
//        {
//            return GetAll().ToList();
//        }


//        public void AddEvent(Event ev)
//        {
//            Add(ev);
//        }

//        public List<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0)
//        {
//            if (provinceId == 0 && cityId == 0) return GetAll().ToList();
//            return GetByPredicate(GenerateFilterForLocale(provinceId, cityId)).ToList();

//        }

//        private Expression<Func<Event, bool>> GenerateFilterForLocale(int provinceId = 0, int cityId = 0)
//        {
//            if (provinceId > 0 && cityId == 0) return x => x.Province.Id == provinceId;

//            if (provinceId == 0 && cityId > 0) return x => x.City.Id == cityId;

//            if (provinceId > 0 && cityId > 0) return x => x.Province.Id == provinceId && x.City.Id == cityId; ;

//            return null;
//        }
//    }
//}
