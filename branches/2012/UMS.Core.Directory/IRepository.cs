using System;
using System.Linq;
using System.Linq.Expressions;

namespace UMS.Core.Directory
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        T Find(string name);
        T InsertOrUpdate(T entity);
        void Delete(string name);
    }
}
