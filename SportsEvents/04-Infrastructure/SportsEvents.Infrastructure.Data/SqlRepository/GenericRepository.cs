
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SportsEvents.Domain.Entities;
using SportsEvents.Domain.Interfaces;
using SportsEvents.Infrastructure.Data.Context;

namespace SportsEvents.Infrastructure.Data.SqlRepository
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


        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {

            var query = _context.Set<T>().Where(x=>true);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

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
            //var query = GetAll().Where(predicate);
            var query = _context.Set<T>().Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
    }
}



