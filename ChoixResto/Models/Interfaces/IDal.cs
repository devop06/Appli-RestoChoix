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
        void ModifierLesRestos(int id, string nom, string tel);
        bool RestaurantExiste(string v);
        Utilisateur ObtenirUtilisateur(int v);
        Utilisateur ObtenirUtilisateur(String name);
        void AjouterUtilisateur(string v1, string v2);
        Utilisateur Authentifier(string v1, string v2);
    }
}
