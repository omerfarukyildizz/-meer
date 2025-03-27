using Pbk.Core.Features.Stages.Update.PlanningSequence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Update.PlanningSequenceRented
{
 
    public sealed class PlanningSequenceRentedCommandValidator : AbstractValidator<PlanningSequenceRentedCommand>
    {
        public PlanningSequenceRentedCommandValidator()
        {
            RuleFor(x => x.PlannedStageId)
            .GreaterThan(0).WithMessage("PlannedStage 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(int.MaxValue).WithMessage($"PlannedStage {int.MaxValue} değerinden büyük olamaz.")
            .NotEmpty().WithMessage("PlannedStage boş olamaz.");

            RuleFor(x => x.PlanningSequence)
                .GreaterThan(0).WithMessage("PlanningSequence 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(int.MaxValue).WithMessage($"PlanningSequence {int.MaxValue} değerinden büyük olamaz.")
                .NotEmpty().WithMessage("PlanningSequence boş olamaz.");
        }
    }
}
