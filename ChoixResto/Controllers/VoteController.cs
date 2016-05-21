using ChoixResto.Models;
using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    [Authorize]
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
            if (id == null || !this.dal.SondageExiste((int)id))
                return HttpNotFound();
            var listeResto = this.dal.ObtenirListeResto();
            RestaurantVoteViewModel listeRestoCheckBox = new RestaurantVoteViewModel();
            listeRestoCheckBox.ListeDesResto = new List<RestaurantCheckBoxViewModel>();
            for (int i = 0; i < listeResto.Count(); i++)
            {
                listeRestoCheckBox.ListeDesResto.Add(new RestaurantCheckBoxViewModel { Id = listeResto[i].Id, EstSelectionne = false, NomEtTelephone = listeResto[i].Nom + " " + listeResto[i].Telephone });
            }
            return View(listeRestoCheckBox);
        }

        [HttpPost]
        public ActionResult Index(RestaurantVoteViewModel v, int? id )
        {
            if (id.HasValue)
            {
                if (this.dal.ADejaVote((int)id, Request.Browser.Browser))
                    return RedirectToAction("AfficheResultat", new { Id = (int)id });
                Utilisateur user = this.dal.ObtenirUtilisateur(Request.Browser.Browser);
                if (user == null)
                    return new HttpUnauthorizedResult();
                if (!ModelState.IsValid)
                    return View(v);
                foreach (RestaurantCheckBoxViewModel restaurantCheckBoxViewModel in v.ListeDesResto.Where(vModel => vModel.EstSelectionne == true))
               {
                    this.dal.AjouterVote((int)id, restaurantCheckBoxViewModel.Id, user.Id);
               }
               return RedirectToAction("AfficheResultat", new { Id = (int)id });
            }
            else
                return RedirectToAction("Index", "Accueil");
        }

        public ActionResult AfficheResultat(int? id)
        {
            if (id.HasValue)
            {
                int idI = (int)id;
                if (!this.dal.SondageExiste(idI))
                    return HttpNotFound();
                if (!this.dal.ADejaVote(idI, Request.Browser.Browser))
                    return View("index", new { Id = idI });
                List<Resultats> lesResultats = this.dal.ObtenirLesResultats(idI).OrderBy(res => res.NombresDeVotes).ToList();
                return View("AfficheResultat", lesResultats);
            }
            else
                return RedirectToAction("Index", "Accueil");
        }
    }
}