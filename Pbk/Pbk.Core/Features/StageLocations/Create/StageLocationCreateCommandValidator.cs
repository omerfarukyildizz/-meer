using Pbk.Core.Features.Invoices.Remove;
using Pbk.Core.Features.Invoices.Update;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.StageLocations.Create
{

    public sealed class StageLocationCreateCommandValidator : AbstractValidator<StageLocationCreateCommand>
    {
        public StageLocationCreateCommandValidator()
        {

            RuleFor(x => x.StageId)
              .GreaterThan(0).WithMessage("Aşama ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("Lokasyon ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.LoadingType)
                .NotEmpty().WithMessage("Yükleme türü boş olamaz.")
                .MaximumLength(20).WithMessage("Yükleme türü en fazla 20 karakter olmalıdır.");

            RuleFor(x => x.SequenceNumber)
                .GreaterThan(0).WithMessage("Sıra numarası 0'dan büyük olmalıdır.");
        }
    }
}
