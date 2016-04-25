using ChoixResto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class RestaurantController : Controller
    {
            private IDal dal;

            public RestaurantController() : this(new Dal())
            {
            }

            public RestaurantController(IDal dalIoc)
            {
                dal = dalIoc;
            }

            public ActionResult Index()
            {
                List<Restaurant> listeDesRestaurants = dal.ObtenirListeResto() ;
                return View(listeDesRestaurants);
            }

            public ActionResult CreerRestaurant()
            {
                return View();
            }

            [HttpPost]
            public ActionResult CreerRestaurant(Restaurant resto)
            {
                if (dal.RestaurantExiste(resto.Nom))
                {
                    ModelState.AddModelError("Nom", "Ce nom de restaurant existe déjà");
                    return View(resto);
                }
                if (!ModelState.IsValid)
                    return View(resto);
                dal.CreerResto(resto.Nom, resto.Telephone);
                return RedirectToAction("Index");
            }

            public ActionResult ModifierRestaurant(int? id)
            {
                if (id.HasValue)
                {
                    Restaurant restaurant = dal.ObtenirListeResto().FirstOrDefault(r => r.Id == id.Value);
                    if (restaurant == null)
                        return View("Error");
                    return View(restaurant);
                }
                else
                    return HttpNotFound();
            }

        [HttpPost]
        public ActionResult ModifierRestaurant(Restaurant resto)
        {
            if (!ModelState.IsValid)
                return View(resto);
            dal.ModifierLesRestos(resto.Id, resto.Nom, resto.Telephone, resto.Email);
            return RedirectToAction("Index");
        }  
    }
}

        
