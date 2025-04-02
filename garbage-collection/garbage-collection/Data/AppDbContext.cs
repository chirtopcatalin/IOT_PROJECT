using garbage_collection.Models;
using Microsoft.EntityFrameworkCore;

namespace garbage_collection.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CollectionModel> collections { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
