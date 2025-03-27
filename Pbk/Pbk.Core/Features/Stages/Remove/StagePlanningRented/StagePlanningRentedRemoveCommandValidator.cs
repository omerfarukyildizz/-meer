using Pbk.Core.Features.Stages.Update.StagePlanning;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Remove.StagePlanningRented
{

    public sealed class StagePlanningRentedRemoveCommandValidator : AbstractValidator<StagePlanningRentedRemoveCommand>
    {
        public StagePlanningRentedRemoveCommandValidator()
        {

            RuleFor(a => a.StageId)
            .NotEmpty().WithMessage("Stage boş olamaz.")
            .GreaterThan(0).WithMessage("Stage 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(int.MaxValue).WithMessage($"Stage {int.MaxValue}'den büyük olamaz.");

            RuleFor(a => a.CarrierId)
                .NotEmpty().WithMessage("Carrier boş olamaz.")
                .GreaterThan(0).WithMessage("Carrier 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(int.MaxValue).WithMessage($"Carrier {int.MaxValue}'den büyük olamaz.");

        }
    }
}
