using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly AppDb _db = new AppDb();

        public IQueryable<Role> All
        {
            get { return _db.Roles; }
        }

        public IQueryable<Role> AllIncluding(params Expression<Func<Role, object>>[] includeProperties)
        {
            var query = All;
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query;
        }

        public Role Find(Guid id)
        {
            return All.SingleOrDefault(r => r.RoleId == id);
        }

        public Role Find(string name)
        {
            return All.SingleOrDefault(r => r.Name == name);
        }

        public Role InsertOrUpdate(Role entity)
        {
            if (entity.RoleId == default(Guid))
            {
                // Insert
                entity.RoleId = Guid.NewGuid();
                _db.Roles.Add(entity);
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
            var role = Find(id);
            _db.Roles.Remove(role);
        }

        public void Delete(string name)
        {
            var role = Find(name);
            _db.Roles.Remove(role);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
