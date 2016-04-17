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
                new ViewModels.PresentationViewModel { Date = new DateTime(2015, 12, 12), Message = "C'est un restaurant typique c#", Restaurant = new Models.Restaurant { Nom = "Beuverie", Telephone = "0645879878" } };
            // test pour selectlist
            List<Models.Restaurant> liste = new List<Models.Restaurant>();
            liste.Add(new Models.Restaurant { Nom = "resto1", Telephone = "01" });
            liste.Add(new Models.Restaurant { Nom = "resto2", Telephone = "02" });
            ViewBag.ListeResto = new SelectList(liste, "Id", "Nom"); // viewbag dynamique, lien fait dynamiquement avec la vue
            return View("Presentation", viewModel); // deuxième paramètre le modèle récupéré
        }

    
    }
}