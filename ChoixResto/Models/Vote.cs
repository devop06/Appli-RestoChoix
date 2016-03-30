using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual Restaurant Resto { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
