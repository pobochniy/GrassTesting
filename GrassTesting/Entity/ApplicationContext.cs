using Microsoft.EntityFrameworkCore;

namespace GrassTesting.Entity
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TravianPlayerHistory> TravianPlayersHistory { get; set; }
        public DbSet<TravianPlayerId> TravianPlayersId { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TravianPlayerHistoryConfiguration());
        }
    }
}
