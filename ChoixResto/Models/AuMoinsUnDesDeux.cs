using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ChoixResto.Models
{
    public class AuMoinsUnDesDeux : ValidationAttribute
    {
        public string pamaretre1 { get; set; }
        public string pamaretre2 { get; set; }
        public AuMoinsUnDesDeux() : base("Au moins un des deux champs doit être remplis")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo[] infos = validationContext.ObjectType.GetProperties();
            var property1 =  infos.FirstOrDefault(p => p.Name == pamaretre1) ;
            var property2 = infos.FirstOrDefault(p => p.Name == pamaretre2);
            string v1 = property1.GetValue(validationContext.ObjectInstance) as string;
            string v2 = property2.GetValue(validationContext.ObjectInstance) as string;
            if (string.IsNullOrWhiteSpace(v1) && string.IsNullOrWhiteSpace(v2))
            {
                return new ValidationResult(ErrorMessage);
            }
            else
                return ValidationResult.Success;
        }
    }
}