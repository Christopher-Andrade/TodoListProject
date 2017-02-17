
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            var res = _context.Set<T>().Where(predicate);
            return res;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
    }
}



