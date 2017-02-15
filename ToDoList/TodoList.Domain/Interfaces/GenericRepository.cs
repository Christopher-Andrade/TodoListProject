using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Domain.Interfaces
{
    public abstract class GenericRepository<C, T> : 
        IGenericRepository<T> where T :
        class where C : DbContext, new()
    {
        private C _entities = new C();

        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }


        public IQueryable<T> GetAll()
        {
            var z = _entities.Set<T>();
            return z;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _entities.AddRange(entity);
        }

        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            var res = _entities.Set<T>().Where(predicate);
            return res;
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
