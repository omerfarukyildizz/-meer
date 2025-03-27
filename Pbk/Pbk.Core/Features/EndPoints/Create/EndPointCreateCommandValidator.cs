using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.EndPoints.Create
{
 
    public sealed class EndPointCreateCommandValidator : AbstractValidator<EndPointCreateCommand>
    {
        public EndPointCreateCommandValidator()
        {
            RuleFor(x => x.DepartmentId)
            .GreaterThan(0).WithMessage("Departman ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.PointName)
                .NotEmpty().WithMessage("Nokta adı boş olamaz.")
                .MaximumLength(255).WithMessage("Nokta adı en fazla 255 karakter olmalıdır.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(255).WithMessage("Adres en fazla 255 karakter olmalıdır.");

            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("Ülke ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Posta kodu boş olamaz.")
                .MaximumLength(20).WithMessage("Posta kodu en fazla 20 karakter olmalıdır.");

            RuleFor(x => x.RelatedPerson)
                .MaximumLength(255).WithMessage("İlgili kişi en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.RelatedPerson));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.")
                .MaximumLength(255).WithMessage("E-posta en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Reference)
                .MaximumLength(255).WithMessage("Referans en fazla 255 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Reference));
 

            RuleFor(x => x.Latitude)
                .MaximumLength(15).WithMessage("Enlem en fazla 15 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Latitude));

            RuleFor(x => x.Longitude)
                .MaximumLength(15).WithMessage("Boylam en fazla 15 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Longitude));
             


        }
    }
}
