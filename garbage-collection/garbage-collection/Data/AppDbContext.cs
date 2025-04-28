using garbage_collection.Models;
using Microsoft.EntityFrameworkCore;

namespace garbage_collection.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<CollectionModel> Collections { get; set; }
        public DbSet<CitizenModel> Citizens { get; set; }
        public DbSet<BinModel> Bins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
    }
}
