using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixRestoTests
{
    class ClassTest
    {

        /* [TestClass]
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
                     dal.CreerResto("Mcdonald's", "0160589788" );
                     System.Collections.Generic.List<Restaurant> listeResto = dal.ObtenirListeResto();
                     Assert.IsNotNull(listeResto);
                     Assert.AreEqual(1, listeResto.Count);
                     Assert.AreEqual("Mcdonald's", listeResto[0].Nom);
                     Assert.AreEqual("0160589788", listeResto[0].Telephone);
                     dal.Dispose();
                 }
             }


             [TestMethod]
             public void ModifierRestaurant_CreationDUnNouveauRestaurantEtChangementNomEtTelephone_LaModificationEstCorrecteApresRechargement()
             {
                 using (IDal dal = new Dal())
                 {
                     dal.CreerResto("Mcdonald's", "0160589788");
                     dal.ModifierLesRestos(1, "macdonald 2", null );
                     List<Restaurant> restos = dal.ObtenirListeResto();
                     Assert.IsNotNull(restos);
                     Assert.AreEqual(1, restos.Count);
                     Assert.AreEqual("macdonald 2", restos[0].Nom);
                     Assert.IsNull(restos[0].Telephone);
                 }
             }
         }*/
    }
}
