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
        // GET: Restaurant
        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                List<Restaurant> lesRestos = dal.ObtenirListeResto();
                return View(lesRestos);
            }
        }

        public ActionResult ModifierRestaurant(int? id)
        {
            if (id.HasValue)
            {
                using (IDal dal = new Dal())
                {
                    Restaurant unResto = dal.ObtenirListeResto().FirstOrDefault(r => r.Id == id);
                    if(unResto == null)
                    {
                        return View("error");
                    }
                    else
                    {
                        return View(unResto);
                    }

                }
            }
            else
                return View("Error");
        }

        /*  [HttpPost]
          public ActionResult ModifierRestaurant(int? id, string nom, string telephone)
          {
              if (id.HasValue)
              {
                  using (IDal dal = new Dal())
                  {
                      dal.ModifierLesRestos((int)id, nom, telephone);
                      return RedirectToAction("Index");
                  }
              }
              else
                  return View("Error");
          }*/
        /// <summary>
        /// Autre solution Binding 
        /// </summary>
        /// <param name="resto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModifierRestaurant(Restaurant resto)
        {
            if (!ModelState.IsValid)
                    return View(resto);
           using (IDal dal = new Dal())
                {
                    dal.ModifierLesRestos(resto.Id, resto.Nom, resto.Telephone);
                    return RedirectToAction("Index");
                }
        }

        public ActionResult CreerRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerRestaurant(Restaurant resto)
        {
            using (IDal dal = new Dal())
            {
                if(dal.RestaurantExiste(resto.Nom))
                {
                    ModelState.AddModelError("Nom", "Restaurant déjà existant !");
                    return View(resto);
                }
                if (!ModelState.IsValid)
                {
                    return View(resto);
                }
                dal.CreerResto(resto.Nom, resto.Telephone);
            }
            return RedirectToAction("Index");
        }
    }
}

        
