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
        IRepository<Setting> Settings { get; }
    }
}
