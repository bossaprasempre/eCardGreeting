using Microsoft.EntityFrameworkCore;

namespace Halloween.Model
{
    public class DbCard : DbContext
    {
        public DbCard() { }

        public DbCard(DbContextOptions<DbCard> options) : base(options) { }

        public DbSet<GreetingCard> GreetingCard { get; set; }
    }
}
