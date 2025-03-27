using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.EndPoints.Remove
{
 
    public sealed class EndPointRemoveCommandValidator : AbstractValidator<EndPointRemoveCommand>
    {
        public EndPointRemoveCommandValidator()
        {

            RuleFor(a => a.PointId)
                .NotEmpty().WithMessage("PointId is required.")
                .GreaterThan(0).WithMessage("PointId must be greater than 0.");
  
        }
    }
}
