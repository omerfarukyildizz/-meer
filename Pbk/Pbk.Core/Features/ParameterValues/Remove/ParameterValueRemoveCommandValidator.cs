using Pbk.Core.Features.ParameterValues.Remove;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.ParameterValues.Remove
{
 
    public sealed class ParameterValueRemoveCommandValidator : AbstractValidator<ParameterValueRemoveCommand>
    {
        public ParameterValueRemoveCommandValidator()
        {

            RuleFor(a => a.ParameterValueId)
                .NotEmpty().WithMessage("ParameterValueId is required.")
                .GreaterThan(0).WithMessage("ParameterValueId must be greater than 0.");
  
        }
    }
}
