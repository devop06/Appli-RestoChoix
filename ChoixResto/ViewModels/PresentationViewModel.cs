using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.ViewModels
{
    public class PresentationViewModel
    {
        [Display(Name = "Le message")]
        public string Message { get; set; }
        public Models.Restaurant Restaurant {get;set;}
        public DateTime Date { get; set; }
        [MaxLength(5, ErrorMessage = "Login charactères insuffisant")]
        public string Login { get; set; }
    }
}
