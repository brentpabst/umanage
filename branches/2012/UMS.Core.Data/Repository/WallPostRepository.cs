using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class WallPostRepository:IRepository<WallPost>
    {
        private readonly AppDb _db = new AppDb();
        public IQueryable<WallPost> All
        {
            get { return _db.WallPosts; }
        }

        public IQueryable<WallPost> AllIncluding(params Expression<Func<WallPost, object>>[] includeProperties)
        {
            return includeProperties.Aggregate(All, (current, prop) => current.Include(prop));
        }

        public WallPost Find(Guid id)
        {
            return All.SingleOrDefault(l => l.PostId == id);
        }

        public WallPost InsertOrUpdate(WallPost entity)
        {
            if(entity.PostId==default(Guid))
            {
                // Insert
                entity.PostId = Guid.NewGuid();
                _db.WallPosts.Add(entity);
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
            var post = Find(id);
            _db.WallPosts.Remove(post);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
