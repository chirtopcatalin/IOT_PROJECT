using Microsoft.EntityFrameworkCore;

namespace garbage_collection.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
