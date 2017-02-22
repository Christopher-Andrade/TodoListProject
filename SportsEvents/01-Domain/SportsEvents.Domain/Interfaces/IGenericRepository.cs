using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SportsEvents.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

       void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);


        void Delete(T entity);


    }
}
