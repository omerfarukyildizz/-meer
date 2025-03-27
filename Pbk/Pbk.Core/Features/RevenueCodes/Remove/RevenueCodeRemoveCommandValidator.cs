using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Features.RevenueCodes.Remove
{
 
    public sealed class RevenueCodeRemoveCommandValidator : AbstractValidator<RevenueCodeRemoveCommand>
    {
        public RevenueCodeRemoveCommandValidator()
        {

            RuleFor(a => a.RevenueCodeId)
                .NotEmpty().WithMessage("RevenueCodeId is required.")
                .GreaterThan(0).WithMessage("RevenueCodeId must be greater than 0.");
  
        }
    }
}
