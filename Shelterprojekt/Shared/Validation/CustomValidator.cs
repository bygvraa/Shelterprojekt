using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelterprojekt.Shared.Validation
{
    public class CustomValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            return new ValidationResult("Validation message to user.",
                new[] { validationContext.MemberName });
        }
    }
}
