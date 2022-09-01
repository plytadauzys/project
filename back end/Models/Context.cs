using Microsoft.EntityFrameworkCore;
// Repository
namespace back_end.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options) { }

        public DbSet<User> Users{ get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }*/
    }
}
