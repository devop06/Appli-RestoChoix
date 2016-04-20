﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    [Table ("Restaurant")]
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant :")]
        [Required]
        public string Nom { get; set; }
        [Display(Name = "Tel :")]
        public string Telephone { get; set; }
    }
}
