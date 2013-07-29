using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class OfficeRepository : IRepository<Office>
    {
        private readonly AppDb _db = new AppDb();

        public IQueryable<Office> All
        {
            get { return _db.Offices; }
        }

        public IQueryable<Office> AllIncluding(params Expression<Func<Office, object>>[] includeProperties)
        {
            var query = All;
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query;
        }

        public Office Find(Guid id)
        {
            return All.SingleOrDefault(o => o.OfficeId == id);
        }

        public Office InsertOrUpdate(Office entity)
        {
            if (entity.OfficeId == default(Guid))
            {
                // Insert
                entity.OfficeId = Guid.NewGuid();
                entity.AddedOn = DateTime.UtcNow;
                _db.Offices.Add(entity);
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
            var office = Find(id);
            _db.Offices.Remove(office);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
