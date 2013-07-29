using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class LocationRepository:IRepository<Location>
    {
        private readonly AppDb _db = new AppDb();

        public IQueryable<Location> All
        {
            get { return _db.Locations; }
        }

        public IQueryable<Location> AllIncluding(params Expression<Func<Location, object>>[] includeProperties)
        {
            var query = All;
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query;
        }

        public Location Find(Guid id)
        {
            return All.SingleOrDefault(l => l.LocationId == id);
        }

        public Location InsertOrUpdate(Location entity)
        {
            if (entity.LocationId == default(Guid))
            {
                entity.IsEnabled = true;

                // Insert
                entity.LocationId = Guid.NewGuid();
                _db.Locations.Add(entity);
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
            var location = Find(id);
            _db.Locations.Remove(location);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
