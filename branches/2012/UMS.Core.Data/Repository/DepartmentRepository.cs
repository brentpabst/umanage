using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly AppDb _db = new AppDb();

        public IQueryable<Department> All
        {
            get { return _db.Departments; }
        }

        public IQueryable<Department> AllIncluding(params Expression<Func<Department, object>>[] includeProperties)
        {
            var query = All;
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query;
        }

        public Department Find(Guid id)
        {
            return All.SingleOrDefault(d => d.DepartmentId == id);
        }

        public Department InsertOrUpdate(Department entity)
        {
            if (entity.DepartmentId == default(Guid))
            {
                // Insert
                entity.DepartmentId = Guid.NewGuid();
                entity.AddedOn = DateTime.UtcNow;
                _db.Departments.Add(entity);
            }
            else
            {
                // Update
                _db.Entry(entity).State = EntityState.Modified;
            }
            return entity;
        }

        public void Delete(Guid id)
        {
            var dep = Find(id);
            _db.Departments.Remove(dep);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
