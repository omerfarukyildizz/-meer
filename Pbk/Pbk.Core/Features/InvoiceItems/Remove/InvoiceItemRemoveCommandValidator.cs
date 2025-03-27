using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.InvoiceItems.Remove
{
 
    public sealed class InvoiceItemRemoveCommandValidator : AbstractValidator<InvoiceItemRemoveCommand>
    {
        public InvoiceItemRemoveCommandValidator()
        {

            RuleFor(a => a.InvoiceItemId)
                .NotEmpty().WithMessage("InvoiceItemId is required.")
                .GreaterThan(0).WithMessage("InvoiceItemId must be greater than 0.");
  
        }
    }
}
