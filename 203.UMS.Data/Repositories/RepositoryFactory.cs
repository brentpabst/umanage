using System;
using System.Collections.Generic;
using System.Data.Entity;
using _203.UMS.Data.Repositories.Sql;

namespace _203.UMS.Data.Repositories
{
    public class RepositoryFactory
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        public RepositoryFactory()
        {
            _repositoryFactories = GetSystemFactories();
        }

        private static IDictionary<Type, Func<DbContext, object>> GetSystemFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>();
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
            return dbContext => new SqlRepository<T>(dbContext);
        }
    }
}
