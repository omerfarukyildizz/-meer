using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.StageLocations.Remove
{
 
    public sealed class StageLocationRemoveCommandValidator : AbstractValidator<StageLocationRemoveCommand>
    {
        public StageLocationRemoveCommandValidator()
        {

            RuleFor(a => a.StageLocationId)
                .NotEmpty().WithMessage("StageLocationId is required.")
                .GreaterThan(0).WithMessage("StageLocationId must be greater than 0.");
  
        }
    }
}
