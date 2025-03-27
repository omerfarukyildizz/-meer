using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Vehicles.Create
{

    public sealed class VehicleCreateCommandValidator : AbstractValidator<VehicleCreateCommand>
    {
        public VehicleCreateCommandValidator()
        {
            RuleFor(x => x.VehicleTypeId)
                       .GreaterThan(0).WithMessage("Araç tipi ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.Plate)
                .NotEmpty().WithMessage("Plaka boş olamaz.")
                .MaximumLength(24).WithMessage("Plaka en fazla 24 karakter olmalıdır.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Departman ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).When(x => x.ProjectId.HasValue).WithMessage("Proje ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.DocumentId)
                .GreaterThan(0).When(x => x.DocumentId.HasValue).WithMessage("Belge ID'si 0'dan büyük olmalıdır.");
 

            RuleFor(x => x.IsRented)
                .NotNull().WithMessage("Kiralık durumu boş olamaz.");


            RuleFor(x => x.CustomerId)
                .GreaterThan(0).When(x => x.CustomerId.HasValue).WithMessage("Müşteri ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.TuvInspection)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("TÜV denetim tarihi bugünden ileri olamaz.")
                .When(x => x.TuvInspection.HasValue);

            RuleFor(x => x.SafetyInspection)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Güvenlik denetim tarihi bugünden ileri olamaz.")
                .When(x => x.SafetyInspection.HasValue);

        }
    }
}
