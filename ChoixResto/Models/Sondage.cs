using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    class Sondage
    {
         public int Id { get; set; }
         public DateTime Date { get; set; }
         public virtual List<Vote> Votes { get; set; }
    }
}
