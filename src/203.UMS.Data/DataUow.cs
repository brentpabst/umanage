﻿using _203.UMS.Data.Interfaces;
using _203.UMS.Data.Repositories.Interfaces;
using _203.UMS.Models.App;
using System;

namespace _203.UMS.Data
{
    public class DataUow : IDbUow, IDisposable
    {
        private SystemDb Db { get; set; }

        public DataUow(IRepositoryProvider repositoryProvider)
        {
            Db = new SystemDb();

            repositoryProvider.Context = Db;
            RepositoryProvider = repositoryProvider;
        }

        // UNIT OF WORK CLASSES/TABLES
        public IRepository<Department> Departments { get { return GetRepository<Department>(); } }
        public IRepository<Location> Locations { get { return GetRepository<Location>(); } }
        public IRepository<Office> Offices { get { return GetRepository<Office>(); } }
        public IRepository<QuickLink> QuickLinks { get { return GetRepository<QuickLink>(); } }
        public IRepository<Setting> Settings { get { return GetRepository<Setting>(); } }
        public IRepository<WallPost> WallPosts { get { return GetRepository<WallPost>(); } }

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