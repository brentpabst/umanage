using System;
using System.Linq;
using System.Linq.Expressions;

namespace _203.UMS.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes);
        T Get(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Guid id);
    }
}
