using ChoixResto.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace ChoixRestoTest
{
    [TestClass]
    public class DalTest
    {
        [TestInitialize]
        public void Purge_avantTest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());
        }

        [TestMethod]
        public void CreerRestaurant_AvecNouveauRestaurant_RetrouveBienLeResto()
        {
            using (IDal dal = new Dal() )
            {
                dal.CreerResto(1, "Mcdonald's", "0160589788" );
                System.Collections.Generic.List<Restaurant> listeResto = dal.ObtenirListeResto();
                Assert.IsNotNull(listeResto);
                Assert.AreEqual(1, listeResto.Count);
                Assert.AreEqual("Mcdonald's", listeResto[0].Nom);
                Assert.AreEqual("0160589788", listeResto[0].Telephone);
                dal.Dispose();
            }
        }
    }
}
