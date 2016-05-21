using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Data.Entity;
using ChoixResto.Models;
using Moq;

namespace ChoixRestoTests
{
    /// <summary>
    /// Description résumée pour VoteControllerTests
    /// </summary>
    [TestClass]
    public class VoteControllerTests
    {
        private IDal dal;
        private int idSondage;
        private ChoixResto.Controllers.VoteController controller;
        public VoteControllerTests()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Index_AvecSondageNormalMaisSansUtilisateur_RenvoiLeBonViewModelEtAfficheLaVue()
        {
          ViewResult indexView =  (ViewResult)controller.Index(this.idSondage);
          ChoixResto.ViewModels.RestaurantVoteViewModel viewModel = (ChoixResto.ViewModels.RestaurantVoteViewModel)indexView.Model;
          Assert.AreEqual(3, viewModel.ListeDesResto.Count);
        }
        [TestMethod]
        public void Index_AvecSondageNormalAvecUtilisateurNayantPasVote_RenvoiLeBonViewModelEtAfficheLaVue()
        {
            ViewResult indexView = (ViewResult)controller.Index(this.idSondage);
            this.dal.AjouterUtilisateur("tutu", "tutumdp");
            this.dal.AjouterUtilisateur("toto", "totomdp");
            ChoixResto.ViewModels.RestaurantVoteViewModel viewModel = (ChoixResto.ViewModels.RestaurantVoteViewModel)indexView.Model;
            this.dal.AjouterVote(this.idSondage, viewModel.ListeDesResto[0].Id, this.dal.ObtenirUtilisateur(1).Id);
            Assert.IsFalse(this.dal.ADejaVote(this.idSondage, this.dal.CreeOuRecupere("toto", "totomdp").Id.ToString()));
            Assert.AreEqual(4, viewModel.ListeDesResto.Count);
            Assert.AreEqual("Resto pinière 0102030405", viewModel.ListeDesResto[0].NomEtTelephone);
            RedirectToRouteResult redirect = (RedirectToRouteResult)this.controller.Index( viewModel, this.idSondage);
            Assert.AreEqual("AfficheResultat", redirect.RouteValues["action"]);
        }

        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            this.dal = new DalEnDur();
            this.idSondage = this.dal.CreerUnSondage();
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(p => p.HttpContext.Request.Browser.Browser).Returns("1");
            controller = new ChoixResto.Controllers.VoteController();
            controller.ControllerContext = controllerContext.Object;
        }

        [TestCleanup]
        public void ApresChaqueTest()
        {
        }
    }
}
