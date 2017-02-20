
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Data.Context;

namespace TodoList.Infrastructure.Data.SqlRepository
{
    public class GenericRepository<T> :
        IGenericRepository<T> where T :
        class  
    {
        private readonly ProjectContext _context;

        public GenericRepository(ProjectContext cc)
        {
            _context = cc;
        }


        public IQueryable<T> GetAll()
        {
            
            return _context.Set<T>();
            
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _context.AddRange(entity);
        }

        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            //_context.Events.Include(x => x.City);
           // _context.Events.Include(x => x.Province);
            var query = GetAll().Where(predicate);
           // DbSet<T> query = _context.Set<T>();
         //   query.Include(IncludesMapping());
           // query.Where(predicate).Include(IncludesMapping());
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

          //  return query;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        private string IncludesMapping()
        {
            var t = typeof(T);
            if (t == typeof(Event))
            {
                return "City";
            }
            return "";
        }
    }
}



