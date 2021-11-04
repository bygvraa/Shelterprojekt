using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Shelterprojekt.Shared.Validation
{
    public class CustomFieldClassProvider : FieldCssClassProvider
    {

        public override string GetFieldCssClass(EditContext editContext,
            in FieldIdentifier fieldIdentifier)
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            return isValid ? "valid": "invalid";
        }

    }
}
