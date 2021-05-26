using Microsoft.EntityFrameworkCore;
using euro_bet.Models;

namespace euro_bet.Data
{
    public class EuroBetContext: DbContext
    {
        public EuroBetContext(DbContextOptions<EuroBetContext> options) : base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Balance> Balance { get; set; }

        public DbSet<Player> Player { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Squad> Squad { get; set; }
        public DbSet<Country> Country { get; set; }

        public DbSet<Fixture> Fixture {get; set; }
    }
}