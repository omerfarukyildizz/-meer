using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Voyages.Create
{

    public sealed class VoyageCreateCommandValidator : AbstractValidator<VoyageCreateCommand>
    {
        public VoyageCreateCommandValidator()
        {


            RuleFor(x => x.TruckId)
                       .GreaterThan(0).WithMessage("Kamyon ID'si 0'dan büyük olmalıdır.")
                       .When(x => x.CarrierId == null, ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.Year)
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Yıl geçerli bir aralıkta olmalıdır.");

            RuleFor(x => x.StatusTypeId)
                .GreaterThan(0).WithMessage("Durum türü ID'si 0'dan büyük olmalıdır.");
             

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Departman ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.TransportPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Taşıma ücreti negatif olamaz.")
                .When(x => x.TransportPrice.HasValue);

            RuleFor(x => x.CurrencyId)
                .GreaterThan(0).When(x => x.CurrencyId.HasValue).WithMessage("Para birimi ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("Açıklama en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.EmptyKm)
                .GreaterThanOrEqualTo(0).WithMessage("Boş kilometre negatif olamaz.");

            
        }
    }
}
