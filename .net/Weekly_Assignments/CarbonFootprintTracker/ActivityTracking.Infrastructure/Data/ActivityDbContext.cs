using ActivityTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityTracking.Infrastructure.Data
{
    public class ActivityDbContext : DbContext
    {
        public ActivityDbContext(DbContextOptions<ActivityDbContext> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<TransportActivity> TransportActivities { get; set; }
        public DbSet<EnergyUsage> EnergyUsages { get; set; }
        public DbSet<WasteActivity> WasteActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().ToTable("Activities");
            modelBuilder.Entity<TransportActivity>().ToTable("TransportActivities");
            modelBuilder.Entity<EnergyUsage>().ToTable("EnergyUsages");
            modelBuilder.Entity<WasteActivity>().ToTable("WasteActivities");
        }
    }
}
