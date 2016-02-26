using System.Data.Entity;

namespace Axado.Models
{
    public class Context : DbContext
    {
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> User { get; set; }

    }

}