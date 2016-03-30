using System.Data.Entity;

namespace ChoixResto.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Restaurant> restaurants { get; set; }
    }
}
