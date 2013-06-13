using _203.UMS.Data.Contracts;
using _203.UMS.Linq;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace _203.UMS.Data
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");

            Db = dbContext;
            DbSet = Db.Set<T>();
        }

        protected DbContext Db { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            return GetAll().IncludeMultiple(includes);
        }

        public virtual T Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = Db.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = Db.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
                DbSet.Attach(entity);
            else
                dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = Db.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
                dbEntityEntry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = Get(id);
            if (entity == null) return;
            Delete(entity);
        }
    }
}
