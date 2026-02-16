using Microsoft.EntityFrameworkCore;
using EmployeeDB.Models;

namespace EmployeeDB.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Emp { get; set; }
        public DbSet<Department> Dept {  get; set; } 
    }
}