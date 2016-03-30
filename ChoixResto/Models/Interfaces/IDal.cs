using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public interface IDal : IDisposable
    {
        List<Restaurant> ObtenirListeResto();
        void CreerResto(int id, String nom, String tel);
    }
}
