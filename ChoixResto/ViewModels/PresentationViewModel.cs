using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.ViewModels
{
    public class PresentationViewModel
    {
        public string Message { get; set; }
        public Models.Restaurant Restaurant {get;set;}
        public DateTime Date { get; set; }
    }
}
