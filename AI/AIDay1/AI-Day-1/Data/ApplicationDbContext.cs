using AI_Day_1.Models;
using Microsoft.EntityFrameworkCore;

namespace AI_Day_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john@example.com",
                    Phone = "9876543210",
                    Address = "New York"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "jane@example.com",
                    Phone = "9123456789",
                    Address = "California"
                }
            );

            // Seed Policies
            modelBuilder.Entity<Policy>().HasData(
                new Policy
                {
                    Id = 1,
                    PolicyType = "Health Insurance",
                    PremiumAmount = 5000,
                    StartDate = new DateTime(2025, 1, 1),
                    EndDate = new DateTime(2026, 1, 1),
                    CustomerId = 1
                },
                new Policy
                {
                    Id = 2,
                    PolicyType = "Life Insurance",
                    PremiumAmount = 7000,
                    StartDate = new DateTime(2025, 2, 1),
                    EndDate = new DateTime(2030, 2, 1),
                    CustomerId = 2
                }
            );

            // Seed Claims
            modelBuilder.Entity<Claim>().HasData(
                new Claim
                {
                    Id = 1,
                    PolicyId = 1,
                    ClaimAmount = 2000,
                    ClaimDate = new DateTime(2025, 3, 10)
                },
                new Claim
                {
                    Id = 2,
                    PolicyId = 2,
                    ClaimAmount = 3000,
                    ClaimDate = new DateTime(2025, 4, 5)
                }
            );
        }
    }
}