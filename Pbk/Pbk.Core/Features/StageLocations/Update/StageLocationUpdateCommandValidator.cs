using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.StageLocations.Update
{
 
    public sealed class StageLocationUpdateCommandValidator : AbstractValidator<StageLocationUpdateCommand>
    {
        public StageLocationUpdateCommandValidator()
        {
            RuleFor(a => a.StageLocationId)
              .NotEmpty().WithMessage("StageLocationId is required.")
              .GreaterThan(0).WithMessage("StageLocationId must be greater than 0.");

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
