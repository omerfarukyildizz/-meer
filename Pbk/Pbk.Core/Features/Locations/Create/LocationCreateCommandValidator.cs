using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Locations.Create
{

    public sealed class LocationCreateCommandValidator : AbstractValidator<LocationCreateCommand>
    {
        public LocationCreateCommandValidator()
        {

            RuleFor(x => x.DepartmentId)
           .GreaterThan(0).WithMessage("Departman ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.LocationName)
                .NotEmpty().WithMessage("Lokasyon adı boş olamaz.")
                .MaximumLength(255).WithMessage("Lokasyon adı en fazla 255 karakter olmalıdır.");

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
                .MaximumLength(10).WithMessage("Posta kodu en fazla 10 karakter olmalıdır.");

            RuleFor(x => x.Latitude)
                .MaximumLength(15).WithMessage("Enlem en fazla 15 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Latitude));

            RuleFor(x => x.Longitude)
                .MaximumLength(15).WithMessage("Boylam en fazla 15 karakter olmalıdır.")
                .When(x => !string.IsNullOrEmpty(x.Longitude));
             
        }
    }
}
