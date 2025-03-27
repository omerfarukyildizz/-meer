using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Stages.Remove
{
 
    public sealed class StageRemoveCommandValidator : AbstractValidator<StageRemoveCommand>
    {
        public StageRemoveCommandValidator()
        {


            RuleFor(a => a.StageId)
            .NotEmpty().WithMessage("Stage boş olamaz.")
            .GreaterThan(0).WithMessage("Stage 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(int.MaxValue).WithMessage($"Stage {int.MaxValue}'den büyük olamaz.");


        }
    }
}
