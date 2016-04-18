using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["resto"] = new ChoixResto.Models.Restaurant { Nom = "Beuverie", Telephone = "0645879878" }; 
            return View(new Models.Utilisateur { Prenom = "user", MotDePasse = "xxxxxxxyyyxxxx" });
        }

        public ActionResult Presentation()
        {
            ChoixResto.ViewModels.PresentationViewModel viewModel = // tout le modèle dans une variable ViewModel
                new ViewModels.PresentationViewModel { Date = new DateTime(2015, 12, 12), Message = "C'est un restaurant typique c#", Restaurant = new Models.Restaurant { Nom = "Beuverie", Telephone = "0645879878"}, Login = "Tony" };
            // test pour selectlist
            List<Models.Restaurant> liste = new List<Models.Restaurant>();
            liste.Add(new Models.Restaurant { Nom = "resto1", Telephone = "01" });
            liste.Add(new Models.Restaurant { Nom = "resto2", Telephone = "02" });
            ViewBag.ListeResto = new SelectList(liste, "Id", "Nom"); // viewbag dynamique, lien fait dynamiquement avec la vue
            return View("Presentation", viewModel); // deuxième paramètre le modèle récupéré
        }
  
        public string ActionLink(int? id)
        {
            string str = "Parametre : " + id;
            return str;
        }
        [ChildActionOnly] // action ne peut être appellé que par un parent dans la vue
        public ActionResult AfficheListeRestaurant()
        {
            List<Models.Restaurant> listeDesRestos = new List<Models.Restaurant>
            {
                new Models.Restaurant { Id = 1, Nom = "Resto pinambour", Telephone = "1234" },
                new Models.Restaurant { Id = 2, Nom = "Resto tologie", Telephone = "1234" },
                new Models.Restaurant { Id = 5, Nom = "Resto ride", Telephone = "5678" },
                new Models.Restaurant{ Id = 9, Nom = "Resto toro", Telephone = "555" },
            };
            return PartialView(listeDesRestos); // envoi la liste à une vue partielle du nom de la méthode du contrôleur ici "AfficheListeRestaurant
        }
    }
}