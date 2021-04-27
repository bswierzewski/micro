using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Version = Core.Entities.Version;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base() { }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"Data source=Micro.db");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<VersionData> VersionsData { get; set; }
    }
}