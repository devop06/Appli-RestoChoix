using ChoixResto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.ViewModels
{
    public class CreerCompteUtisateurViewModel : IValidatableObject
    {
        [Required]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Veuillez choisir un mot de passe")]
        public string MotDePasse { get; set; }
        [Required(ErrorMessage = "Veuillez répéter le mot de passe")]
        public string MotDePasseVerif { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MotDePasse != MotDePasseVerif)
                yield return new ValidationResult("Les deux mots de passes ne sont pas identiques", new[] { "MotDePasse" });
        }

    }
}
