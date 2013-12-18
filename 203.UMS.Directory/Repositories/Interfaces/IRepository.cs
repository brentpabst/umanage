using System;
using System.Linq;

namespace _203.UMS.Directory.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
    }
}
