using System.Data.Entity;
using UMS.Core.Data.Models.App;

namespace UMS.Core.Data
{
    public sealed class SystemInit : DropCreateDatabaseAlways<AppDb>
    {
        protected override void Seed(AppDb ctx)
        {
            // Pre-Populate Data Here
            //base.Seed(new DemoData(ctx).Generate());
            base.Seed(new DefaultData(ctx).Load());
        }
    }

    public class AppDb : DbContext
    {
        public AppDb()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Log> Log { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<QuickLink> QuickLinks { get; set; }
        public DbSet<WallPost> WallPosts { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
