using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    [Table ("Restaurant")]
    public class Restaurant //: IValidatableObject
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant :")]
        [Required(ErrorMessage = "Le nom du restaurant doit être saisi")]
        public string Nom { get; set; }
        
        [Display(Name = "Tél :")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le numéro de téléphone est incorrect")]
        public string Telephone { get; set; }
        [AuMoinsUnDesDeux(pamaretre1 = "Telephone", pamaretre2 = "Email", ErrorMessage = "Au moins un des deux")]
        public string Email { get; set; }
    }
}
