using _203.UMS.Data.Init;
using _203.UMS.Models.App;
using System.Data.Entity;

namespace _203.UMS.Data
{
    public class SystemDb : DbContext
    {
        public SystemDb()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        // Model to Table Mapping
        // TODO: Add new table mapping/wireups here
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Location>().Property(l => l.Latitude).HasPrecision(10, 7);
            base.OnModelCreating(modelBuilder);
        }

        // Database Seeding
        static SystemDb()
        {
            Database.SetInitializer(new SystemDbInitializer());
        }
    }
}
