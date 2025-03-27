using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Carriers.Remove
{
 
    public sealed class CarrierRemoveCommandValidator : AbstractValidator<CarrierRemoveCommand>
    {
        public CarrierRemoveCommandValidator()
        {

            RuleFor(a => a.CarrierId)
                .NotEmpty().WithMessage("CarrierId is required.")
                .GreaterThan(0).WithMessage("CarrierId must be greater than 0.");
  
        }
    }
}
