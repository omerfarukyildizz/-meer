using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Carriers.Update
{
 
    public sealed class CarrierUpdateCommandValidator : AbstractValidator<CarrierUpdateCommand>
    {
        public CarrierUpdateCommandValidator()
        {
            RuleFor(a => a.CarrierId)
               .NotEmpty().WithMessage("CarrierId is required.")
               .GreaterThan(0).WithMessage("CarrierId must be greater than 0.");

            RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("DepartmanId alanı kodu boş olamaz.");

            RuleFor(x => x.TimocomId)
            .NotEmpty().WithMessage("TimocomId alanı kodu boş olamaz.");

            RuleFor(x => x.CarrierName)
                .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                .MaximumLength(255).WithMessage("İsim en fazla 255 karakter olmalıdır.");
 

            RuleFor(x => x.PaymentTerms)
                .GreaterThan(0).When(x => x.PaymentTerms.HasValue)
                .WithMessage("Ödeme koşulları 0'dan büyük olmalıdır.");

            RuleFor(x => x.DocumentId)
                .GreaterThan(0).When(x => x.DocumentId.HasValue)
                .WithMessage("Belge ID 0'dan büyük olmalıdır.");

            RuleFor(x => x.ContactPerson)
                .MaximumLength(255).WithMessage("İlgili kişi en fazla 255 karakter olmalıdır.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Geçerli bir e-posta adresi girin.");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olmalıdır.");
             


        }
    }
}
