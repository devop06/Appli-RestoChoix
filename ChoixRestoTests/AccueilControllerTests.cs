using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ChoixResto.Models;
using ChoixResto.Controllers;

namespace ChoixRestoTests
{
    [TestClass]
    public class AccueilControllerTests
    {
        [TestMethod]
        public void AccueilController_Index_RenvoiDefautlView()
        {
            ChoixResto.Controllers.AccueilController acceuil = new ChoixResto.Controllers.AccueilController();
            ViewResult view = (ViewResult)acceuil.Index();
            Assert.AreEqual(string.Empty, view.ViewName);
        }

        [TestMethod]
        public void AccueilController_IndexPost_RenvoiActionVote()
        {
            ChoixResto.Controllers.AccueilController accueilCtrl = new ChoixResto.Controllers.AccueilController();
            RedirectToRouteResult action = (RedirectToRouteResult)accueilCtrl.IndexPost();
            Assert.AreEqual("Index", action.RouteValues["action"]);
            Assert.AreEqual("Vote", action.RouteValues["controller"]);
        }

        [TestMethod]
        public void RestaurantController_ModifierRestaurantAvecRestoInvalide_RenvoiVueParDefaut()
        {
            using (IDal dal = new DalEnDur())
            {
                RestaurantController c = new RestaurantController(dal);
                c.ModelState.AddModelError("Nom", "le nom du restaurant doit être saisi");

                ViewResult resultat = (ViewResult)c.ModifierRestaurant(new Restaurant { Id = 1, Nom = null, Telephone = "0164209743" });
                Assert.AreEqual(string.Empty, resultat.ViewName);
                Assert.IsFalse(resultat.ViewData.ModelState.IsValid);
            }
              
        }
    }
}
