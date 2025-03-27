using Pbk.Core.Features.Stages.Update.StagePlanning;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.StagePlanningRented
{

    public sealed class StagePlanningRentedCommandValidator : AbstractValidator<StagePlanningCommand>
    {
        public StagePlanningRentedCommandValidator()
        {
            RuleFor(a => a.StageId)
            .NotEmpty().WithMessage("Stage boş olamaz.")
            .GreaterThan(0).WithMessage("Stage 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(int.MaxValue).WithMessage($"Stage {int.MaxValue}'den büyük olamaz.");

            RuleFor(a => a.VehicleId)
                .NotEmpty().WithMessage("Vehicle boş olamaz.")
                .GreaterThan(0).WithMessage("Vehicle 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(int.MaxValue).WithMessage($"Vehicle {int.MaxValue}'den büyük olamaz.");

        }
    }
}
