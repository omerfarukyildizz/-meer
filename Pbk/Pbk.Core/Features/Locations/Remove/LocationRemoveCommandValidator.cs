using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Locations.Remove
{
 
    public sealed class LocationRemoveCommandValidator : AbstractValidator<LocationRemoveCommand>
    {
        public LocationRemoveCommandValidator()
        {

            RuleFor(a => a.LocationId)
                .NotEmpty().WithMessage("LocationId is required.")
                .GreaterThan(0).WithMessage("LocationId must be greater than 0.");
  
        }
    }
}
