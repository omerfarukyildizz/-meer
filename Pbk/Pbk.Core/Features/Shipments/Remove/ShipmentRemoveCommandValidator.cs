using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Shipments.Remove
{
 
    public sealed class ShipmentRemoveCommandValidator : AbstractValidator<ShipmentRemoveCommand>
    {
        public ShipmentRemoveCommandValidator()
        {

            RuleFor(a => a.ShipmentId)
                .NotEmpty().WithMessage("ShipmentId is required.")
                .GreaterThan(0).WithMessage("ShipmentId must be greater than 0.");
  
        }
    }
}
