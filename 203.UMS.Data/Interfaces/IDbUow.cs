using _203.UMS.Data.Repositories.Interfaces;
using _203.UMS.Models.App;

namespace _203.UMS.Data.Interfaces
{
    public interface IDbUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        // TODO: Add new repositories and models here
        IRepository<Department> Departments { get; }
        IRepository<Location> Locations { get; }
        IRepository<Office> Offices { get; }
        IRepository<QuickLink> QuickLinks { get; }
        IRepository<Setting> Settings { get; }
        IRepository<WallPost> WallPosts { get; }
    }
}
