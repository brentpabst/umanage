using System;
using System.Linq;
using System.Linq.Expressions;

namespace UMS.Core.Data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(Guid id);
        T InsertOrUpdate(T entity);
        void Delete(Guid id);
        void Save();
    }
}
