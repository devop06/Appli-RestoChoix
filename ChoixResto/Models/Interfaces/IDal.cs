using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public interface IDal : IDisposable
    {
        List<Restaurant> ObtenirListeResto();
        void CreerResto(String nom, String tel);
        void ModifierLesRestos(int id, string nom, string tel, string email);
        bool RestaurantExiste(string v);
        Utilisateur CreeOuRecupere(string nom, string motDePasse);
        Utilisateur ObtenirUtilisateur(int v);
        Utilisateur ObtenirUtilisateur(String name);
        int AjouterUtilisateur(string v1, string v2);
        Utilisateur Authentifier(string v1, string v2);
        bool ADejaVote(int v1, string v2);
        int CreerUnSondage();
        void AjouterVote(int idSondage, int idResto, int idUtilisateur);
        List<Resultats> ObtenirLesResultats(int idSondage);
    }
}
