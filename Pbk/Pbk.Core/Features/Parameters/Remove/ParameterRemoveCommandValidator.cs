using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.Parameters.Remove
{
 
    public sealed class ParameterRemoveCommandValidator : AbstractValidator<ParameterRemoveCommand>
    {
        public ParameterRemoveCommandValidator()
        {

            RuleFor(a => a.ParameterId)
                .NotEmpty().WithMessage("ParameterId is required.")
                .GreaterThan(0).WithMessage("ParameterId must be greater than 0.");
  
        }
    }
}
