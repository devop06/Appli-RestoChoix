using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Display(Name="Prénom")]
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string MotDePasse { get; set; }
    }
}
