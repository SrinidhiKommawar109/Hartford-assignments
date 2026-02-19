
using InsuranceTypes.Models;
using Microsoft.EntityFrameworkCore;

namespace 
InsuranceTypes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<InsuranceType> InsuranceTypes { get; set; }
    }
}