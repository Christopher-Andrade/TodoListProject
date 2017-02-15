using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoList.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

       void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        IQueryable<T> GetByPredicate(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        void Delete(T entity);


    }
}
