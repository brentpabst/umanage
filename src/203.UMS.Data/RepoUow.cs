using _203.UMS.Data.Contracts;
using _203.UMS.Models.App;
using System;

namespace _203.UMS.Data
{
    public class RepoUow : IRepoUow, IDisposable
    {
        private SystemDb Db { get; set; }

        public RepoUow(IRepositoryProvider repositoryProvider)
        {
            Db = new SystemDb();

            repositoryProvider.DbContext = Db;
            RepositoryProvider = repositoryProvider;
        }

        // TODO: Add new models here to access them in the UOW
        public IRepository<Setting> Settings { get { return GetRepository<Setting>(); } }

        public void Commit()
        {
            Db.SaveChanges();
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Db != null)
            {
                Db.Dispose();
            }
        }
    }
}
