using _203.UMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace _203.UMS.Data.Repositories.Sql
{
    public class SqlRepositoryProvider : IRepositoryProvider
    {
        public SqlRepositoryProvider(RepositoryFactory repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        public DbContext Context { get; set; }

        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
                return (T)repoObj;

            return MakeRepository<T>(factory, Context);
        }

        protected Dictionary<Type, object> Repositories { get; private set; }

        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        public void SetRepository<T>(T repository) where T : class
        {
            Repositories[typeof(T)] = repository;
        }

        private readonly RepositoryFactory _repositoryFactories;
    }
}
