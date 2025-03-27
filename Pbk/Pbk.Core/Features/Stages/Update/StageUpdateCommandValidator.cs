using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update
{
 
    public sealed class StageUpdateCommandValidator : AbstractValidator<StageUpdateCommand>
    {
        public StageUpdateCommandValidator()
        {
            RuleFor(a => a.StageId)
              .NotEmpty().WithMessage("StageId boş olamaz.")
              .GreaterThan(0).WithMessage("StageId'si 0'dan büyük olmalıdır.");
 
            RuleFor(x => x.SourceLocationId)
                .GreaterThan(0).WithMessage("SourceLocationId 0'dan büyük olmalıdır.");

            RuleFor(x => x.TargetLocationId)
                .GreaterThan(0).WithMessage("TargetLocationId 0'dan büyük olmalıdır.");

            RuleFor(x => x.LoadingTime)
                .NotEmpty().WithMessage("LoadingTime boş olamaz.");

            RuleFor(x => x.UnloadingTime)
                .NotEmpty().WithMessage("UnloadingTime boş olamaz.")
                .GreaterThanOrEqualTo(x => x.LoadingTime).WithMessage("Boşaltma zamanı yükleme zamanından önce olamaz.");
 
        }
    }
}
