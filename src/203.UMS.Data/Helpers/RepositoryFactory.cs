using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace _203.UMS.Data.Helpers
{
    public class RepositoryFactories
    {

        private IDictionary<Type, Func<DbContext, object>> GetSystemFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {
                //{typeof(IMyRepository), dbContext => new MyRepository(dbContext)}
            };
        }

        public RepositoryFactories()
        {
            _repositoryFactories = GetSystemFactories();
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EFRepository<T>(dbContext);
        }

        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;
    }
}
