using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class Context : DbContext
    {
        public DbSet<DeckTable> deckTables { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
