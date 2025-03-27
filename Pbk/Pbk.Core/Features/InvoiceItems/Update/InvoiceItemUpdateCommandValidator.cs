using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.InvoiceItems.Update
{
 
    public sealed class InvoiceItemUpdateCommandValidator : AbstractValidator<InvoiceItemUpdateCommand>
    {
        public InvoiceItemUpdateCommandValidator()
        {
            RuleFor(a => a.InvoiceItemId)
              .NotEmpty().WithMessage("InvoiceItemId is required.")
              .GreaterThan(0).WithMessage("InvoiceItemId must be greater than 0.");

            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Müşteri ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.DepartmentId).GreaterThan(0).WithMessage("Departman ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.RevenueCodeId).GreaterThan(0).WithMessage("Gelir Kodu ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.SectorId).GreaterThan(0).WithMessage("Sektör ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Tutar 0'dan büyük olmalıdır.");
            RuleFor(x => x.CurrencyId).GreaterThan(0).WithMessage("Para birimi ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.Year).InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Yıl geçerli bir aralıkta olmalıdır.");

        }
    }
}
