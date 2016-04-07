using System.Data.Entity;

namespace ChoixResto.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Sondage> Sondages { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}
