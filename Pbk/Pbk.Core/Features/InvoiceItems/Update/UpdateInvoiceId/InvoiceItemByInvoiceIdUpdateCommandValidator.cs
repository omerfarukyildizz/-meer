using Pbk.Core.Features.InvoiceItems.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.InvoiceItems.Update.UpdateInvoiceId
{


    public sealed class InvoiceItemByInvoiceIdUpdateCommandValidator : AbstractValidator<InvoiceItemByInvoiceIdUpdateCommand>
    {
        public InvoiceItemByInvoiceIdUpdateCommandValidator()
        {
            RuleFor(a => a.InvoiceItemId)
              .NotEmpty().WithMessage("InvoiceItemId is required.")
              .GreaterThan(0).WithMessage("InvoiceItemId must be greater than 0.");

            RuleFor(a => a.InvoiceId)
             .NotEmpty().WithMessage("InvoiceItemId is required.");
        }
    }
}
