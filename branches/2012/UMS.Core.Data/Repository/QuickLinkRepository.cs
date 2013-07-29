using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class QuickLinkRepository : IRepository<QuickLink>
    {
        private readonly AppDb _db = new AppDb();

        public IQueryable<QuickLink> All
        {
            get { return _db.QuickLinks; }
        }

        public IQueryable<QuickLink> AllIncluding(params Expression<Func<QuickLink, object>>[] includeProperties)
        {
            var query = All;
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query;
        }

        public QuickLink Find(Guid id)
        {
            return All.SingleOrDefault(l => l.LinkId == id);
        }

        public QuickLink InsertOrUpdate(QuickLink entity)
        {
            if (entity.LinkId == default(Guid))
            {
                // Insert
                entity.LinkId = Guid.NewGuid();
                _db.QuickLinks.Add(entity);
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
            var link = Find(id);

            _db.QuickLinks.Remove(link);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
