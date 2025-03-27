using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Invoices.Update
{
 
    public sealed class InvoiceUpdateCommandValidator : AbstractValidator<InvoiceUpdateCommand>
    {
        public InvoiceUpdateCommandValidator()
        {
            RuleFor(a => a.InvoiceId)
              .NotEmpty().WithMessage("InvoiceId is required.")
              .GreaterThan(0).WithMessage("InvoiceId must be greater than 0.");

            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Müşteri ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.DepartmentId).GreaterThan(0).WithMessage("Departman ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Tutar 0'dan büyük olmalıdır.");
            RuleFor(x => x.CurrencyId).GreaterThan(0).WithMessage("Para birimi ID 0'dan büyük olmalıdır.");
            RuleFor(x => x.Year).InclusiveBetween(2000, DateTime.Now.Year).WithMessage("Yıl geçerli bir aralıkta olmalıdır.");
            RuleFor(x => x.InvoiceNo).MaximumLength(20).WithMessage("Fatura numarası en fazla 20 karakter olmalıdır.");
            RuleFor(x => x.IntegrationNo).MaximumLength(20).WithMessage("Entegrasyon numarası en fazla 20 karakter olmalıdır.");
            RuleFor(x => x.Description).MaximumLength(255).WithMessage("Açıklama en fazla 255 karakter olmalıdır.");
            RuleFor(x => x.CustomerReference).MaximumLength(50).WithMessage("Müşteri referansı en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.BGLReference).MaximumLength(50).WithMessage("BGL referansı en fazla 50 karakter olmalıdır.");

        }
    }
}
