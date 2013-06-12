using System.Linq;

namespace _203.UMS.Directory
{
    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        T Find(string name);
        T InsertOrUpdate(T entity);
        void Delete(string name);
    }
}
