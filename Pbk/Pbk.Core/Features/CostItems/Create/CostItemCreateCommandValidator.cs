using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.CostItems.Create
{
 
    public sealed class CostItemCreateCommandValidator : AbstractValidator<CostItemCreateCommand>
    {
        public CostItemCreateCommandValidator()
        {
            RuleFor(x => x.DepartmentId).GreaterThan(0).WithMessage("Departman Kimliği sıfırdan büyük olmalıdır.");
            //RuleFor(x => x.Vendor)
            //    .NotEmpty().WithMessage("Satıcı alanı boş olamaz.")
            //    .MaximumLength(14).WithMessage("Satıcı en fazla 14 karakter olmalıdır.");
            RuleFor(x => x.ExpenseCodeId).GreaterThan(0).WithMessage("Gider Kodu Kimliği sıfırdan büyük olmalıdır.");
            RuleFor(x => x.SectorId).GreaterThan(0).WithMessage("Sektör Kimliği sıfırdan büyük olmalıdır.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");
            RuleFor(x => x.CurrencyId).GreaterThan(0).WithMessage("Para Birimi Kimliği sıfırdan büyük olmalıdır.");
            RuleFor(x => x.InvoiceNo)
                .NotEmpty().WithMessage("Fatura Numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Fatura Numarası en fazla 20 karakter olmalıdır.");
            RuleFor(x => x.Year).GreaterThan(2000).WithMessage("Geçerli bir yıl giriniz.");  

        }
    }
}
