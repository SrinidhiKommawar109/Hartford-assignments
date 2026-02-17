using Microsoft.EntityFrameworkCore;
using BasicAuthentication.Models;

namespace BasicAuthentication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserLogin> Users { get; set; }
    }
}