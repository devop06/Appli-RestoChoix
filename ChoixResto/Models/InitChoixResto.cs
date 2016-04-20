using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    /// <summary>
    /// Hérite de dropcreatedatabase avec notre contexte en paramètre
    /// quand cette classe sera instanciée elle permettre de supprimer la base et repartir avec les données 
    /// de base à savoir celles de la méthodes "seed"
    /// Appelle dans la fichier Global.asax.cs
    /// </summary>
    class InitChoixResto : DropCreateDatabaseAlways<BddContext>
    {
        protected override void Seed(BddContext context)
        {
            context.Restaurants.Add(new Restaurant { Id = 1, Nom = "Resto pinambour", Telephone = "123" });
            context.Restaurants.Add(new Restaurant { Id = 2, Nom = "Resto pinière", Telephone = "456" });
            context.Restaurants.Add(new Restaurant { Id = 3, Nom = "Resto toro", Telephone = "789" });
            base.Seed(context);
        }
    }
}
