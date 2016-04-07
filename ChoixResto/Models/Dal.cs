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
            return this.bdd.Restaurants.ToList();
        }

        public void ModifierLesRestos(int id, string nom, string tel)
        {
            Restaurant r = this.bdd.Restaurants.FirstOrDefault(resto => resto.Id == id);
            if(r != null)
            {
                r.Nom = nom;
                r.Telephone = tel;
                this.bdd.SaveChanges();
            }
        }

        public void CreerResto(string nom, string tel)
        {
            this.bdd.Restaurants.Add(new Restaurant { Nom = nom, Telephone = tel });
            this.bdd.SaveChanges();
        }

        public bool RestaurantExiste(string v)
        {
            bool existe = this.ObtenirListeResto().Exists(r => r.Nom == v);
            return existe;
        }

        public Utilisateur ObtenirUtilisateur(int v)
        {
             return this.bdd.Utilisateurs.FirstOrDefault(util => util.Id == v);
        }

        public Utilisateur ObtenirUtilisateur(string name)
        {
            return this.bdd.Utilisateurs.FirstOrDefault(util => util.Prenom == name);
        }

        public void Dispose()
        {
            this.bdd.Dispose();
        }

        public int AjouterUtilisateur(string v1, string v2)
        {
            Utilisateur user = new Utilisateur { Prenom = v1, MotDePasse = Fonctions.Password.EncodeMD5(v2) };
            this.bdd.Utilisateurs.Add(user);
            this.bdd.SaveChanges();
            return user.Id;
        }

        public Utilisateur Authentifier(string v1, string v2)
        {
            v2 = Fonctions.Password.EncodeMD5(v2);
            Utilisateur foundUser = this.bdd.Utilisateurs.FirstOrDefault(user => user.Prenom == v1 && user.MotDePasse == v2);
            return foundUser;
        }

        public bool ADejaVote(int idSondage, string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
                if (sondage.Votes == null)
                    return false;
                return sondage.Votes.Any(v => v.Utilisateur != null && v.Utilisateur.Id == id);
            }
            return false;
        }

        public int CreerUnSondage()
        {
            Sondage sondage = new Sondage { Date = DateTime.Now };
            this.bdd.Sondages.Add(sondage);
            this.bdd.SaveChanges();
            return sondage.Id;
        }

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Restaurant rest = bdd.Restaurants.First(r => r.Id == idResto);
            Utilisateur user = bdd.Utilisateurs.First(u => u.Id == idUtilisateur);
            Vote vote = new Vote { Resto = rest, Utilisateur = user };

            Sondage sondage = this.bdd.Sondages.First(s => s.Id == idSondage);
            if(sondage.Votes  == null)
            {
                sondage.Votes = new List<Vote>();
            }
            sondage.Votes.Add(vote); 
            this.bdd.SaveChanges();
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            List<Restaurant> restaurants = this.ObtenirListeResto();
            List<Resultats> resultats = new List<Resultats>();
            Sondage sondage = bdd.Sondages.First(s => s.Id == idSondage);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
            {
                int idRestaurant = grouping.Key;
                Restaurant resto = restaurants.First(r => r.Id == idRestaurant);
                int nombreDeVotes = grouping.Count();
                resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombresDeVotes = nombreDeVotes });
            }
            return resultats;
        }
    }
}
