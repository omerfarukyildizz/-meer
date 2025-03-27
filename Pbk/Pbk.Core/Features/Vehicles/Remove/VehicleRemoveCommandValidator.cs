using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Vehicles.Remove
{
 
    public sealed class VehicleRemoveCommandValidator : AbstractValidator<VehicleRemoveCommand>
    {
        public VehicleRemoveCommandValidator()
        {

            RuleFor(a => a.VehicleId)
                .NotEmpty().WithMessage("VehicleId ocationId is required.")
                .GreaterThan(0).WithMessage("VehicleId cationId must be greater than 0.");
  
        }
    }
}
