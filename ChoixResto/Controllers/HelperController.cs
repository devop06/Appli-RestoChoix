using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class HelperController : Controller
    {
        // GET: Helper
        public ActionResult Index()
        {
            ViewData["resto"] = new ChoixResto.Models.Restaurant { Nom = "Beuverie", Telephone = "0645879878" };
            return View(new Models.Utilisateur { Prenom = "user", MotDePasse = "xxxxxxxyyyxxxx" });
        }
    }
}