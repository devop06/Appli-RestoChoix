using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ChoixResto.Models
{
    public class DeuxIdentiques : ValidationAttribute
    {
        public string pamaretre1 { get; set; }
        public string pamaretre2 { get; set; }
        public DeuxIdentiques() : base("Les deux mot de passes doivent être identiques")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo[] infos = validationContext.ObjectType.GetProperties();
            var property1 =  infos.FirstOrDefault(p => p.Name == pamaretre1) ;
            var property2 = infos.FirstOrDefault(p => p.Name == pamaretre2);
            string v1 = property1.GetValue(validationContext.ObjectInstance) as string;
            string v2 = property2.GetValue(validationContext.ObjectInstance) as string;
            if (v1 != v2)
            {
                return new ValidationResult(ErrorMessage);
            }
            else
                return ValidationResult.Success;
        }
    }
}