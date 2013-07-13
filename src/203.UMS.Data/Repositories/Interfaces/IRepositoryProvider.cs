using System;
using System.Data.Entity;

namespace _203.UMS.Data.Repositories.Interfaces
{
    public interface IRepositoryProvider
    {
        DbContext Context { get; set; }

        IRepository<T> GetRepositoryForEntityType<T>() where T : class;

        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;

        void SetRepository<T>(T repository) where T : class;
    }
}
