using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data.Repository
{
    public class SettingRepository : IRepository<Setting>
    {
        private AppDb _db = new AppDb();

        public IQueryable<Setting> All
        {
            get { return _db.Settings; }
        }

        public IQueryable<Setting> AllIncluding(params Expression<Func<Setting, object>>[] includeProperties)
        {
            var query = All;
            foreach (var prop in includeProperties)
            {
                query = query.Include(prop);
            }
            return query;
        }

        public Setting Find(Guid id)
        {
            return All.SingleOrDefault(l => l.SettingId == id);
        }

        public Setting Find(string key)
        {
            return All.SingleOrDefault(l => l.Key == key);
        }

        public Setting InsertOrUpdate(Setting entity)
        {
            var s = Find(entity.Key);
            if (s == null)
            {
                entity.SettingId = Guid.NewGuid();
                _db.Settings.Add(entity);
            }
            else
            {
                s.Value = entity.Value;
                s.IsEncrypted = entity.IsEncrypted;
                _db.Entry(s).State = EntityState.Modified;
            }
            return entity;
        }

        public void Delete(Guid id)
        {
            var s = Find(id);

            _db.Settings.Remove(s);
        }

        public void Delete(string key)
        {
            var s = Find(key);

            _db.Settings.Remove(s);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
