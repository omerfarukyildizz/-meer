using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Voyages.Remove
{
 
    public sealed class VoyageRemoveCommandValidator : AbstractValidator<VoyageRemoveCommand>
    {
        public VoyageRemoveCommandValidator()
        {

            RuleFor(a => a.VoyageId)
                .NotEmpty().WithMessage("VoyageId  ocationId is required.")
                .GreaterThan(0).WithMessage("VoyageId  cationId must be greater than 0.");
  
        }
    }
}
