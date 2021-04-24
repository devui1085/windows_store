using Store.DataAccess.EntityMapping;
using Store.DomainModel.Entity;
using System.Data.Entity;

namespace Store.DataAccess.Context
{
    public partial class WindowsStoreContext : DbContext
    {
        static WindowsStoreContext()
        {
            Database.SetInitializer<WindowsStoreContext>(null);
        }

        public WindowsStoreContext()
            : base("Name=WindowsStoreContext")
        {
        }

        public DbSet<App> Apps { get; set; }
        public DbSet<AppCategory> AppCategories { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }
        public DbSet<AppVersion> AppVersions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<LegalPerson> LegalPeople { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<NaturalPerson> NaturalPeople { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<FeaturedApp> FeaturedApps { get; set; }
        public DbSet<DownloadHistory> DownloadHistories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ActiveDeviceHistory> ActiveDeviceHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppMap());
            modelBuilder.Configurations.Add(new AppCategoryMap());
            modelBuilder.Configurations.Add(new ScreenshotMap());
            modelBuilder.Configurations.Add(new AppVersionMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new LegalPersonMap());
            modelBuilder.Configurations.Add(new MembershipMap());
            modelBuilder.Configurations.Add(new NaturalPersonMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PlatformMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new RatingMap());
            modelBuilder.Configurations.Add(new FeaturedAppMap());
            modelBuilder.Configurations.Add(new DownloadHistoryMap());
            modelBuilder.Configurations.Add(new DeviceMap());
            modelBuilder.Configurations.Add(new ActiveDeviceHistoryMap());
        }
    }
}
