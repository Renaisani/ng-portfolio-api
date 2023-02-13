using Microsoft.EntityFrameworkCore;

namespace TestNETCoreApp_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Blog> Blog => Set<Blog>();
    }
}
