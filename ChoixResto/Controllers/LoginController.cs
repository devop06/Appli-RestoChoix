using ChoixResto.Models;
using ChoixResto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChoixResto.Controllers
{
    public class LoginController : Controller
    {
        private IDal dal;
        public LoginController(): this(new Dal()) { }
        public LoginController(IDal dal)
        {
            this.dal = dal;
        }
        // GET: Login
        public ActionResult Index()
        {
            ViewModels.UtilisateurViewModel viewModel = new ViewModels.UtilisateurViewModel() { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Utilsateur = dal.ObtenirUtilisateur(HttpContext.User.Identity.Name);
            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(UtilisateurViewModel viewModel)
        {
            // à continuer
            return null;
        }
    }
}