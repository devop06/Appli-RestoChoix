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
    public class Restaurant : IValidatableObject
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant :")]
        [Required(ErrorMessage = "Le nom du restaurant doit être saisi")]
        public string Nom { get; set; }
        
        [Display(Name = "Tél :")]
    //    [Required(ErrorMessage = "Numéro obligatoire")] // tableau validate du dessous prend le relais pour le tel et email 
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le numéro de téléphone est incorrect")]
        public string Telephone { get; set; }
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Telephone))
            {
                yield return new ValidationResult("Au moins un des deux champs doit être spécifié", new[] { "Telephone", "Email"});
            }
        }
    }
}
