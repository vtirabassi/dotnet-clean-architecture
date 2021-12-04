using System;
using System.Linq.Expressions;

namespace Application.Intefaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);

        Task<T> Get(Expression<Func<T, bool>> predicate);

        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}