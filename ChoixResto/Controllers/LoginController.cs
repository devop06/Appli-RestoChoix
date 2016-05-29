using ChoixResto.Models;
using ChoixResto.ViewModels;
using System.Web.Security;
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
        public ActionResult Index(UtilisateurViewModel viewModel, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                Utilisateur user = this.dal.Authentifier(viewModel.Utilsateur.Prenom, viewModel.Utilsateur.MotDePasse);
                if(user != null)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    return Redirect(ReturnUrl);
                }
                ModelState.AddModelError("Utilsateur.Prenom", "Utilisateur non reconnu");
            }
                return View(viewModel);
           
        }

        public ActionResult CreerCompte()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreerCompte(ViewModels.CreerCompteUtisateurViewModel user)
        {
            if(ModelState.IsValid)
            {
                int id = this.dal.AjouterUtilisateur(user.Prenom, user.MotDePasse);
                FormsAuthentication.SetAuthCookie(id.ToString(), false);
                return Redirect("/");
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}