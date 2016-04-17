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
            ChoixResto.ViewModels.PresentationViewModel viewModel =
                new ViewModels.PresentationViewModel { Date = new DateTime(2015, 12, 12), Message = "C'est un restaurant typique c#", Restaurant = new Models.Restaurant { Nom = "Beuverie", Telephone = "0645879878" } };

            return View("Presentation", viewModel);
        }
    }
}