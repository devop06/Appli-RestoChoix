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

        public void ModifierLesRestos(int id, string nom, string tel)
        {
            Restaurant r = this.bdd.restaurants.FirstOrDefault(resto => resto.Id == id);
            if(r != null)
            {
                r.Nom = nom;
                r.Telephone = tel;
                this.bdd.SaveChanges();
            }
        }

        public void CreerResto(string nom, string tel)
        {
            this.bdd.restaurants.Add(new Restaurant { Nom = nom, Telephone = tel });
            this.bdd.SaveChanges();
        }

        public bool RestaurantExiste(string v)
        {
            bool existe = this.ObtenirListeResto().Exists(r => r.Nom == v);
            return existe;
        }
    }
}
