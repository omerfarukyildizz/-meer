using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Translations.Create
{

    public sealed class TranslationCreateCommandValidator : AbstractValidator<TranslationCreateCommand>
    {
        public TranslationCreateCommandValidator()
        {

            RuleFor(x => x.LanguageId)
            .GreaterThan(0).WithMessage("Dil ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.ServiceId)
                .GreaterThan(0).WithMessage("Servis ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.TranslateKey)
                .NotEmpty().WithMessage("Çeviri anahtarı boş olamaz.");

            RuleFor(x => x.TranslateValue)
                .NotEmpty().WithMessage("Çeviri değeri boş olamaz.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Aktiflik durumu boş olamaz.")
                .When(x => x.IsActive.HasValue);
        }
    }
}
