using ChoixResto.Models;
using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class VoteController : Controller
    {
        private IDal dal;
        public VoteController():this(new Dal()) { }
        public VoteController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        public ActionResult Index(int? id)
        {
            var listeResto = this.dal.ObtenirListeResto();
            RestaurantVoteViewModel listeRestoCheckBox = new RestaurantVoteViewModel();
            for(int i = 0; i < listeResto.Count();i++)
            {
                listeRestoCheckBox.ListeDesResto.Add(new RestaurantCheckBoxViewModel { Id = listeResto[i].Id, EstSelectionne = false, NomEtTelephone = listeResto[i].Nom + listeResto[i].Telephone });
            }
        

            return View(listeRestoCheckBox);
        }
    }
}