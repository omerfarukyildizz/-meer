using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Invoices.Remove
{
 
    public sealed class InvoiceRemoveCommandValidator : AbstractValidator<InvoiceRemoveCommand>
    {
        public InvoiceRemoveCommandValidator()
        {

            RuleFor(a => a.InvoiceId)
                .NotEmpty().WithMessage("InvoiceId is required.")
                .GreaterThan(0).WithMessage("InvoiceId must be greater than 0.");
  
        }
    }
}
