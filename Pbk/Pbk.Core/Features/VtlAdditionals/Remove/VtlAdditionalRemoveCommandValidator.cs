using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.VtlAdditionals.Remove
{
 
    public sealed class VtlAdditionalRemoveCommandValidator : AbstractValidator<VtlAdditionalRemoveCommand>
    {
        public VtlAdditionalRemoveCommandValidator()
        {

            RuleFor(a => a.ShipmentId)
                .NotEmpty().WithMessage("ShipmentId  ocationId is required.")
                .GreaterThan(0).WithMessage("ShipmentId  cationId must be greater than 0.");
  
        }
    }
}
