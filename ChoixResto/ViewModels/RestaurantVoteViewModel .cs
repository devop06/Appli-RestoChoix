using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.ViewModels
{
    public class RestaurantVoteViewModel
    {
        public List<RestaurantCheckBoxViewModel> ListeDesResto { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return null;
            // à faire !
        }
    }
}
