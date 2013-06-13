using _203.UMS.Models.App;

namespace _203.UMS.Data.Contracts
{
    public interface IRepoUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        // TODO: Add new repositories and models here
        IRepository<Setting> Settings { get; }
    }
}
