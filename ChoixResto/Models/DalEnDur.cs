using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public class DalEnDur : IDal
    {
        private List<Restaurant> listeDesRestaurants;
        private List<Utilisateur> listeDesUtilisateurs;
        private List<Sondage> listeDessondages;

        public DalEnDur()
        {
                listeDesRestaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Nom = "Resto pinambour", Telephone = "0102030405", Email =  null},
                new Restaurant { Id = 2, Nom = "Resto pinière", Telephone = "0102030405", Email = "tutu@gmail.com"},
                new Restaurant { Id = 3, Nom = "Resto toro", Telephone = "0102030405", Email = "tata@gmail.com" },
            };
            listeDesUtilisateurs = new List<Utilisateur>();
            listeDessondages = new List<Sondage>();
        }

        public List<Restaurant> ObtenirListeResto()
        {
            return listeDesRestaurants;
        }

        public void CreerResto(string nom, string tel)
        {
            int id = listeDesRestaurants.Count == 0 ? 1 : listeDesRestaurants.Max(r => r.Id) + 1;
            listeDesRestaurants.Add(new Restaurant { Id = id, Nom = nom, Telephone = tel });
        }


        public void ModifierLesRestos(int id, string nom, string tel, string email)
        {
            Restaurant resto = listeDesRestaurants.FirstOrDefault(r => r.Id == id);
            if (resto != null)
            {
                resto.Nom = nom;
                resto.Telephone = tel;
                resto.Email = email;
            }
        }
      

        public bool RestaurantExiste(string nom)
        {
            return listeDesRestaurants.Any(resto => string.Compare(resto.Nom, nom, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public int AjouterUtilisateur(string nom, string motDePasse)
        {
            int id = listeDesUtilisateurs.Count == 0 ? 1 : listeDesUtilisateurs.Max(u => u.Id) + 1;
            listeDesUtilisateurs.Add(new Utilisateur { Id = id, Prenom = nom, MotDePasse = motDePasse });
            return id;
        }

        public Utilisateur Authentifier(string nom, string motDePasse)
        {
            return listeDesUtilisateurs.FirstOrDefault(u => u.Prenom == nom && u.MotDePasse == motDePasse);
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return listeDesUtilisateurs.FirstOrDefault(u => u.Id == id);
        }

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
                return ObtenirUtilisateur(id);
            return null;
        }

        public int CreerUnSondage()
        {
            int id = listeDessondages.Count == 0 ? 1 : listeDessondages.Max(s => s.Id) + 1;
            listeDessondages.Add(new Sondage { Id = id, Date = DateTime.Now, Votes = new List<Vote>() });
            return id;
        }

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Vote vote = new Vote
            {
                Resto = listeDesRestaurants.First(r => r.Id == idResto),
                Utilisateur = listeDesUtilisateurs.First(u => u.Id == idUtilisateur)
            };
            Sondage sondage = listeDessondages.First(s => s.Id == idSondage);
            sondage.Votes.Add(vote);
        }

        public bool ADejaVote(int idSondage, string idStr)
        {
            Utilisateur utilisateur = ObtenirUtilisateur(idStr);
            if (utilisateur == null)
                return false;
            Sondage sondage = listeDessondages.First(s => s.Id == idSondage);
            return sondage.Votes.Any(v => v.Utilisateur.Id == utilisateur.Id);
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            List<Restaurant> restaurants = this.ObtenirListeResto();
            List<Resultats> resultats = new List<Resultats>();
            Sondage sondage = listeDessondages.First(s => s.Id == idSondage);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
            {
                int idRestaurant = grouping.Key;
                Restaurant resto = restaurants.First(r => r.Id == idRestaurant);
                int nombreDeVotes = grouping.Count();
                resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombresDeVotes = nombreDeVotes });
            }
            return resultats;
        }

        public void Dispose()
        {
            listeDesRestaurants = new List<Restaurant>();
            listeDesUtilisateurs = new List<Utilisateur>();
            listeDessondages = new List<Sondage>();
        }
    }
}
