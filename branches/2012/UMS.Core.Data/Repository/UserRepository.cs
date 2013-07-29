using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDb _db = new AppDb();

        public IQueryable<User> All
        {
            get { return _db.Users; }
        }

        public IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties)
        {
            var query = All;
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query;
        }

        public User Find(Guid id)
        {
            return All.SingleOrDefault(u => u.UserId == id);
        }

        public User Find(string name)
        {
            return All.SingleOrDefault(u => u.UserName == name);
        }

        public User InsertOrUpdate(User entity)
        {
            if (entity.UserId == default(Guid))
            {
                // Insert
                entity.UserId = Guid.NewGuid();
                _db.Users.Add(entity);
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
            var user = Find(id);
            _db.Users.Remove(user);
        }

        public void Delete(string name)
        {
            var user = Find(name);
            _db.Users.Remove(user);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
