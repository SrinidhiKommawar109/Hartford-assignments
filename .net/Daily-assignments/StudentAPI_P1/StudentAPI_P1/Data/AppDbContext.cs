//data manager class
//DbContext = data controller or data manager
using Microsoft.EntityFrameworkCore;
using StudentAPI_P1.Models;
namespace StudentAPI_P1.Data
{
    public class AppDbContext:DbContext
    {
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //DbSet is List of student objects equivalent to List<Student> Students
        public DbSet<Student> Students { get; set; }
    }
}


