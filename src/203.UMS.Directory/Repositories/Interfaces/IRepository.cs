using System;
using System.Linq;

namespace _203.UMS.Directory.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
