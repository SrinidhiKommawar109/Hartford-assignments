using Microsoft.EntityFrameworkCore;

namespace Products_Asg.Models
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) :base(options)
        { }
        public DbSet<ProductItem> ProductItems { get; set; } = null!;
    }
}
