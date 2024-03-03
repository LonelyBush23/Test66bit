using _66bitTest.Models;
using Microsoft.EntityFrameworkCore;

namespace _66bitTest.Models.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public AppDbContext(string connectionString) : base(GetOptions<AppDbContext>(connectionString)) { }

        protected static DbContextOptions<TContext> GetOptions<TContext>(string connectionString) where TContext : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(connectionString);
            return optionsBuilder.Options;
        }

        public DbSet<Human> Human { get; set; }

        public DbSet<Team> Team { get; set; }

        public DbSet<Direction> Direction { get; set; }
    }
}
