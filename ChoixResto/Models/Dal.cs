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
        private Fonctions.Password password; 

        public Dal()
        {
            this.bdd = new BddContext();
            this.password = new Fonctions.Password();
        }

        public List<Restaurant> ObtenirListeResto()
        {
            return this.bdd.restaurants.ToList();
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

        public Utilisateur ObtenirUtilisateur(int v)
        {
             return this.bdd.utilisateurs.FirstOrDefault(util => util.Id == v);
        }

        public Utilisateur ObtenirUtilisateur(string name)
        {
            return this.bdd.utilisateurs.FirstOrDefault(util => util.Prenom == name);
        }

        public void Dispose()
        {
            this.bdd.Dispose();
        }

        public void AjouterUtilisateur(string v1, string v2)
        {
            this.bdd.utilisateurs.Add(new Utilisateur { Prenom = v1, MotDePasse = Fonctions.Password.EncodeMD5(v2) });
            this.bdd.SaveChanges();
        }

        public Utilisateur Authentifier(string v1, string v2)
        {
            v2 = Fonctions.Password.EncodeMD5(v2);
            Utilisateur foundUser = this.bdd.utilisateurs.FirstOrDefault(user => user.Prenom == v1 && user.MotDePasse == v2);
            return foundUser;
        }

        public bool ADejaVote(int v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
