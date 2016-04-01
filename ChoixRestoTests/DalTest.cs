using ChoixResto.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChoixRestoTest
{
    [TestClass]
    public class DalTest
    {
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
            }
        }
    }
}
