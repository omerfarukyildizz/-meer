using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Drivers.Remove
{
 
    public sealed class DriverRemoveCommandValidator : AbstractValidator<DriverRemoveCommand>
    {
        public DriverRemoveCommandValidator()
        {

            RuleFor(a => a.DriverId)
                .NotEmpty().WithMessage("DriverId is required.")
                .GreaterThan(0).WithMessage("DriverId must be greater than 0.");
  
        }
    }
}
