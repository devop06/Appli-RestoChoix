using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            this.bdd = new BddContext();
        }

        public List<Restaurant> ObtenirListeResto()
        {
            return this.bdd.restaurants.ToList();
        }

        public void Dispose()
        {
            this.bdd.Dispose();
        }

        public void CreerResto(int id, string nom, string tel)
        {
            this.bdd.restaurants.Add(new Restaurant { Id = 1, Nom = "Yuelu", Telephone = "0698589855" });
            this.bdd.SaveChanges();
        }
    }
}
