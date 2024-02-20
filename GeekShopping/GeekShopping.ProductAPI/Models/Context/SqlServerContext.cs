using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Models.Context
{
    public class SqlServerContext : DbContext
    {
        protected SqlServerContext()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options){ }

        public DbSet<Product> Products { get; set; }
    }
}
