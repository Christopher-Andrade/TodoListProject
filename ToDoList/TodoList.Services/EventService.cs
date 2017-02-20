﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TodoList.Domain.Entities;
using TodoList.Domain.Entities.Comment;
using TodoList.Domain.Interfaces;
using TodoList.Services.Interfaces;

namespace TodoList.Services
{
    //public class EventService : IEventService
    //{
    //    private readonly IEventRepo _eventRepo;
    //    private readonly ICommentRepo _commentRepo;


    //    public EventService(IEventRepo eventRepo, ICommentRepo commentRepo)
    //    {
    //        _eventRepo = eventRepo;
    //        _commentRepo = commentRepo;
    //    }
    //    public IEnumerable<Event> GetAllEvents()
    //    {
    //        return _eventRepo.GetAllEvents();
    //    }

    //    public IEnumerable<Comment> GetCommentsForEvent(int eventId)
    //    {
    //        return _commentRepo.GetCommentsByParentIdentifier(eventId.ToString());
    //    }

    //    public void AddEvent(Event ev)
    //    {
    //        _eventRepo.AddEvent(ev);

    //    }

    //    public IEnumerable<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0)
    //    {
    //        return _eventRepo.GetEventsByLocale(provinceId, cityId);
    //    }
    //}

    public class EventService : IEventService
    {
        private readonly IGenericRepository<Event> _eventRepo;
      //  private readonly ICommentRepo _commentRepo;


        public EventService(IGenericRepository<Event> eventRepo)//, ICommentRepo commentRepo)
        {
            _eventRepo = eventRepo;
        //    _commentRepo = commentRepo;
        }
        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepo.GetAll();
        }

        public IEnumerable<Comment> GetCommentsForEvent(int eventId)
        {
            return null;
           // return _commentRepo.GetCommentsByParentIdentifier(eventId.ToString());
        }

        public void AddEvent(Event ev)
        {
            _eventRepo.Add(ev);

        }

        public IEnumerable<Event> GetEventsByLocale(int provinceId = 0, int cityId = 0)
        {
            if (provinceId == 0 && cityId == 0) return _eventRepo.GetAll().ToList();
            return _eventRepo.GetByPredicate(GenerateFilterForLocale(provinceId, cityId),  x => x.City, x=> x.Province).ToList();
        }


        private Expression<Func<Event, bool>> GenerateFilterForLocale(int provinceId = 0, int cityId = 0)
        {
            if (provinceId > 0 && cityId == 0) return x => x.Province.Id == provinceId;

            if (provinceId == 0 && cityId > 0) return x => x.City.Id == cityId;

            if (provinceId > 0 && cityId > 0) return x => x.Province.Id == provinceId && x.City.Id == cityId; ;

            return null;
        }
    }
}

